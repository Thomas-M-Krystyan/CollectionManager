var inputEl = document.getElementById('number-check');
var messageEl = document.getElementById('number-check-message');
var submitButton = document.querySelector('form input[type="submit"]');
var notNumber = 'ERROR: Not a number';
var correctAnswer = 'Correct answer';
var incorrectAnswer = 'Incorrect answer';
inputEl.addEventListener('keyup', function () {
    var inputText = parseInt(inputEl.value);
    var message = '';
    var disable = true;
    if (isNaN(inputText)) {
        message = notNumber;
    }
    else if (inputText % 2 === 0) {
        message = correctAnswer;
        disable = false;
    }
    else {
        message = incorrectAnswer;
    }
    messageEl.innerText = message;
    submitButton.disabled = disable;
});
//# sourceMappingURL=submitValidation.js.map