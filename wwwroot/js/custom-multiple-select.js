class CustomMultipleSelect {
    constructor(originalSelect) {
        this.originalSelect = originalSelect;
        this.customSelect = null;
        this.trigger = null;
        this.options = null;
        this.tagsContainer = null;
        this.selectedOptions = [];
        this.init();
    }

    init() {
        this.createCustomSelect();
        this.bindEvents();
        this.updateTriggerText();
        this.updateTags();
    }

    createCustomSelect() {
        this.customSelect = document.createElement('div');
        this.customSelect.className = 'custom-multiselect';

        this.trigger = document.createElement('button');
        this.trigger.className = 'multiselect-trigger';
        this.trigger.type = 'button';

        this.tagsContainer = document.createElement('div');
        this.tagsContainer.className = 'multiselect-tags';

        this.options = document.createElement('div');
        this.options.className = 'multiselect-options';

        Array.from(this.originalSelect.options).forEach(option => {
            const customOption = this.createCustomOption(option);
            this.options.appendChild(customOption);
        });

        this.customSelect.appendChild(this.trigger);
        this.customSelect.appendChild(this.tagsContainer);
        this.customSelect.appendChild(this.options);

        this.originalSelect.parentNode.insertBefore(this.customSelect, this.originalSelect.nextSibling);
        this.originalSelect.classList.add('select-hidden');
    }

    createCustomOption(option) {
        const customOption = document.createElement('div');
        customOption.className = `multiselect-option ${option.selected ? 'selected' : ''}`;
        customOption.textContent = option.textContent;
        customOption.dataset.value = option.value;

        if (!option.disabled) {
            customOption.addEventListener('click', () => {
                this.toggleOption(option.value);
            });
        }

        if (option.disabled) {
            customOption.classList.add('disabled');
        }

        return customOption;
    }

    bindEvents() {
        this.trigger.addEventListener('click', (e) => {
            e.stopPropagation();
            this.toggleOptions();
        });

        document.addEventListener('click', () => {
            this.closeOptions();
        });

        document.addEventListener('keydown', (e) => {
            if (e.key === 'Escape') {
                this.closeOptions();
            }
        });
    }

    toggleOptions() {
        this.options.classList.toggle('active');
        this.trigger.classList.toggle('active');
    }

    closeOptions() {
        this.options.classList.remove('active');
        this.trigger.classList.remove('active');
    }

    toggleOption(value) {
        const option = this.originalSelect.querySelector(`option[value="${value}"]`);
        if (option) {
            option.selected = !option.selected;
            this.updateSelectedOptions();
            this.updateTriggerText();
            this.updateOptionSelection(value, option.selected);
            this.updateTags();

            this.originalSelect.dispatchEvent(new Event('change'));
        }
    }

    removeOption(value) {
        const option = this.originalSelect.querySelector(`option[value="${value}"]`);
        if (option) {
            option.selected = false;
            this.updateSelectedOptions();
            this.updateTriggerText();
            this.updateOptionSelection(value, false);
            this.updateTags();

            this.originalSelect.dispatchEvent(new Event('change'));
        }
    }

    updateSelectedOptions() {
        this.selectedOptions = Array.from(this.originalSelect.selectedOptions).map(opt => ({
            value: opt.value,
            text: opt.textContent
        }));
    }

    updateTriggerText() {
        this.updateSelectedOptions();

        if (this.selectedOptions.length === 0) {
            this.trigger.textContent = 'Выберите родительские семьи';
            this.trigger.classList.add('placeholder');
        } else {
            this.trigger.textContent = `Выбрано: ${this.selectedOptions.length}`;
            this.trigger.classList.remove('placeholder');
        }
    }

    updateOptionSelection(value, isSelected) {
        const customOption = this.options.querySelector(`[data-value="${value}"]`);
        if (customOption) {
            if (isSelected) {
                customOption.classList.add('selected');
            } else {
                customOption.classList.remove('selected');
            }
        }
    }

    updateTags() {
        this.tagsContainer.innerHTML = '';

        this.selectedOptions.forEach(option => {
            const tag = document.createElement('div');
            tag.className = 'multiselect-tag';

            const tagText = document.createElement('span');
            tagText.textContent = option.text;

            const removeBtn = document.createElement('button');
            removeBtn.className = 'multiselect-tag-remove';
            removeBtn.textContent = ' × ';
            removeBtn.type = 'button';
            removeBtn.addEventListener('click', (e) => {
                e.stopPropagation();
                this.removeOption(option.value);
            });

            tag.appendChild(tagText);
            tag.appendChild(removeBtn);
            this.tagsContainer.appendChild(tag);
        });
    }
}

document.addEventListener('DOMContentLoaded', function () {
    document.querySelectorAll('select[multiple].multiselect-input').forEach(select => {
        new CustomMultipleSelect(select);
    });
});