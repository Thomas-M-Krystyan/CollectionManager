var inputEl = document.getElementById('number-check');
var messageEl = document.getElementById('number-check-message');
var submitButton = document.querySelector('form input[type="submit"]');
var emptyAnswer = '';
var notNumber = 'ERROR: Not a number';
var correctAnswer = 'Correct answer';
var incorrectAnswer = 'Incorrect answer';
inputEl.addEventListener('keyup', function () {
    // Empty input
    if (inputEl.value === emptyAnswer) {
        messageEl.innerText = emptyAnswer;
        submitButton.disabled = true;
        return;
    }
    // Valid input
    var inputText = parseInt(inputEl.value);
    if (inputText % 2 === 0) {
        messageEl.innerText = correctAnswer;
        submitButton.disabled = false;
        return;
    }
    // Invalid input
    var message;
    if (isNaN(inputText)) {
        message = notNumber;
    }
    else {
        message = incorrectAnswer;
    }
    messageEl.innerText = message;
    submitButton.disabled = true;
});
//# sourceMappingURL=submitValidation.js.map