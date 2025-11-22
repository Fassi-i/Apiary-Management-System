class CustomSelect {
    constructor(originalSelect) {
        this.originalSelect = originalSelect;
        this.customSelect = null;
        this.trigger = null;
        this.clearBtn = null;
        this.options = null;
        this.isRequired = originalSelect.hasAttribute('required');
        this.init();
    }

    init() {
        this.createCustomSelect();
        this.bindEvents();
    }

    createCustomSelect() {
        this.customSelect = document.createElement('div');
        this.customSelect.className = 'custom-select';

        this.trigger = document.createElement('button');
        this.trigger.className = 'select-trigger';
        this.trigger.type = 'button';

        const triggerText = document.createElement('span');
        triggerText.className = 'select-trigger-text';

        this.clearBtn = document.createElement('button');
        this.clearBtn.className = 'select-clear';
        this.clearBtn.type = 'button';
        this.clearBtn.innerHTML = '×';
        this.clearBtn.title = 'Очистить выбор';

        this.options = document.createElement('div');
        this.options.className = 'select-options';

        Array.from(this.originalSelect.options).forEach(option => {
            const customOption = document.createElement('div');
            customOption.className = `select-option ${option.disabled ? 'disabled' : ''} ${option.selected ? 'selected' : ''}`;
            customOption.textContent = option.textContent;
            customOption.dataset.value = option.value;

            if (!option.disabled) {
                customOption.addEventListener('click', () => {
                    this.selectOption(option.value);
                });
            }

            this.options.appendChild(customOption);
        });

        this.trigger.appendChild(triggerText);
        this.trigger.appendChild(this.clearBtn);
        this.customSelect.appendChild(this.trigger);
        this.customSelect.appendChild(this.options);

        this.originalSelect.parentNode.insertBefore(this.customSelect, this.originalSelect.nextSibling);
        this.originalSelect.classList.add('select-hidden');

        this.updateTriggerText();
    }

    bindEvents() {
        this.trigger.addEventListener('click', (e) => {
            if (e.target !== this.clearBtn) {
                e.stopPropagation();
                this.toggleOptions();
            }
        });

        this.clearBtn.addEventListener('click', (e) => {
            e.stopPropagation();
            this.clearSelection();
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

    selectOption(value) {
        this.originalSelect.value = value;

        this.updateTriggerText();
        this.updateSelectedOption(value);
        this.closeOptions();

        this.originalSelect.dispatchEvent(new Event('change'));
    }

    clearSelection() {
        this.originalSelect.value = '';

        this.updateTriggerText();
        this.updateSelectedOption('');
        this.closeOptions();

        this.originalSelect.dispatchEvent(new Event('change'));
    }

    updateTriggerText() {
        const selectedOption = this.originalSelect.options[this.originalSelect.selectedIndex];
        const triggerText = this.trigger.querySelector('.select-trigger-text');

        if (selectedOption && selectedOption.value !== '') {
            triggerText.textContent = selectedOption.textContent;
            this.trigger.classList.add('has-value');
        } else {
            const placeholder = this.originalSelect.querySelector('option[disabled][selected]') ||
                this.originalSelect.querySelector('option[disabled]');
            triggerText.textContent = placeholder ? placeholder.textContent : 'Выберите значение';
            this.trigger.classList.remove('has-value');
        }
    }

    updateSelectedOption(value) {
        this.options.querySelectorAll('.select-option').forEach(option => {
            option.classList.remove('selected');
        });

        if (value) {
            const selectedCustomOption = this.options.querySelector(`[data-value="${value}"]`);
            if (selectedCustomOption) {
                selectedCustomOption.classList.add('selected');
            }
        }
    }
}

document.addEventListener('DOMContentLoaded', function () {
    document.querySelectorAll('select.select-input').forEach(select => {
        new CustomSelect(select);
    });
});