const inputEl = document.getElementById('number-check') as HTMLInputElement;
const messageEl = document.getElementById('number-check-message') as HTMLElement;
const submitButton = document.querySelector('form input[type="submit"]') as HTMLInputElement;

const emptyAnswer: string = '';
const notNumber: string = 'ERROR: Not a number';
const correctAnswer: string = 'Correct answer';
const incorrectAnswer: string = 'Incorrect answer';

inputEl.addEventListener('keyup', function () {
    // Empty input
    if (inputEl.value === emptyAnswer) {
        messageEl.innerText = emptyAnswer;
        submitButton.disabled = true;

        return;
    }

    // Valid input
    const inputText: number = parseInt(inputEl.value);

    if (inputText % 2 === 0) {
        messageEl.innerText = correctAnswer;
        submitButton.disabled = false;

        return;
    }

    // Invalid input
    let message: string;

    if (isNaN(inputText)) {
        message = notNumber;
    }
    else {
        message = incorrectAnswer;
    }

    messageEl.innerText = message;
    submitButton.disabled = true;
});