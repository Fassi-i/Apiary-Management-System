class CustomDateInput {
    constructor(container) {
        this.container = container;
        this.input = null;
        this.originalInput = null;
        this.fieldName = container.getAttribute('data-field-name') || 'BirthDate';
        this.init();
    }

    init() {
        this.createInput();
        this.bindEvents();
    }

    createInput() {
        this.input = document.createElement('input');
        this.input.className = 'date-input';
        this.input.type = 'text';
        this.input.placeholder = 'дд.мм.гггг';
        this.input.maxLength = 10;

        this.originalInput = document.createElement('input');
        this.originalInput.type = 'hidden';
        this.originalInput.name = this.fieldName;
        this.originalInput.id = this.fieldName;

        this.container.appendChild(this.input);
        this.container.appendChild(this.originalInput);
    }

    bindEvents() {
        this.input.addEventListener('input', (e) => {
            this.formatDate(e);
        });

        this.input.addEventListener('keydown', (e) => {
            this.handleKeyDown(e);
        });

        this.input.addEventListener('paste', (e) => {
            this.handlePaste(e);
        });
    }

    formatDate(e) {
        let value = e.target.value.replace(/\D/g, '');
        let formattedValue = '';

        for (let i = 0; i < value.length; i++) {
            if (i === 2 || i === 4) {
                formattedValue += '.';
            }
            if (i < 8) {
                formattedValue += value[i];
            }
        }

        e.target.value = formattedValue;
        this.updateOriginalValue();
    }

    handleKeyDown(e) {
        if ([8, 9, 13, 27, 46].includes(e.keyCode) ||
            (e.keyCode >= 37 && e.keyCode <= 40)) {
            return;
        }

        if ((e.keyCode === 65 || e.keyCode === 67 || e.keyCode === 86 || e.keyCode === 88) && e.ctrlKey) {
            return;
        }

        if ((e.keyCode < 48 || e.keyCode > 57) && (e.keyCode < 96 || e.keyCode > 105)) {
            e.preventDefault();
        }
    }

    handlePaste(e) {
        e.preventDefault();
        const paste = (e.clipboardData || window.clipboardData).getData('text');
        const numbers = paste.replace(/\D/g, '').slice(0, 8);

        let formattedValue = '';
        for (let i = 0; i < numbers.length; i++) {
            if (i === 2 || i === 4) {
                formattedValue += '.';
            }
            formattedValue += numbers[i];
        }

        this.input.value = formattedValue;
        this.updateOriginalValue();
    }

    updateOriginalValue() {
        const value = this.input.value;

        this.originalInput.value = value;

        if (this.isValidDate(value)) {
            const [day, month, year] = value.split('.');
            const isoDate = `${year}-${month.padStart(2, '0')}-${day.padStart(2, '0')}`;
            this.originalInput.value = isoDate;
        } else {
            this.originalInput.value = '';
        }
    }

    isValidDate(dateString) {
        if (!dateString || dateString.length !== 10) return false;

        const parts = dateString.split('.');
        if (parts.length !== 3) return false;

        const day = parseInt(parts[0], 10);
        const month = parseInt(parts[1], 10);
        const year = parseInt(parts[2], 10);

        if (isNaN(day) || isNaN(month) || isNaN(year)) return false;
        if (day < 1 || day > 31) return false;
        if (month < 1 || month > 12) return false;

        const daysInMonth = new Date(year, month, 0).getDate();
        if (day > daysInMonth) return false;

        return true;
    }

    setDate(isoDate) {
        if (isoDate) {
            const date = new Date(isoDate);
            const day = date.getDate().toString().padStart(2, '0');
            const month = (date.getMonth() + 1).toString().padStart(2, '0');
            const year = date.getFullYear();

            this.input.value = `${day}.${month}.${year}`;
            this.updateOriginalValue();
        }
    }
}

document.addEventListener('DOMContentLoaded', function () {
    const dateContainers = document.querySelectorAll('.date-input-container');
    dateContainers.forEach(container => {
        new CustomDateInput(container);
    });
});