
interface Window {
    words: string[];
}


namespace Hangman {
    export function startGame() {
        const words = window.words;

        const gameStatuses = { Winning: "Winning", Playing: "Playing", Losing: "Losing", GiveUp: "GiveUp", Start: "Start" };
        let currentGameStatus = gameStatuses.Start;
        let msg = (document.querySelector("#msg") as HTMLElement);
        let answer = (document.querySelector("#txtAnswer") as HTMLInputElement);
        let triesRemaining = (document.querySelector("#txtTriesRemaining") as HTMLInputElement);
        let triesRemainingNumber = parseInt(triesRemaining.value, 10);
        let usedLettersDisplay = (document.querySelector("#txtUsedLetters") as HTMLInputElement);
        let score = (document.querySelector("#score") as HTMLInputElement);
        const maskedWord = (document.querySelector("#maskedWord") as HTMLElement);
        let currentWord = "";
        const keyboardButtons = document.querySelectorAll<HTMLButtonElement>(".key");
        let usedLetters: string[] = [];
        const btnNewGame = (document.querySelector("#btnNewGame") as HTMLButtonElement);
        const btnGiveUp = (document.querySelector("#btnGiveUp") as HTMLButtonElement);
        const btnReset = (document.querySelector("#btnReset") as HTMLButtonElement);

        btnNewGame.addEventListener("click", startGame);
        btnGiveUp.addEventListener("click", gameGiveUp);
        btnReset.addEventListener("click", gameReset);

        btnGiveUp.disabled = true;
        btnReset.disabled = true;

        keyboardButtons.forEach(btn => btn.addEventListener("click", handleLetterSelection));

        function startGame() {
            newGameMode();
            currentGameStatus = gameStatuses.Playing;
            currentWord = pickRandomWord().toUpperCase();
            setGameMessageDisplay();
            updateMaskedWord();
            keyboardButtons.forEach(btn => btn.disabled = false);
            setTriesRemaining(8);
        }
        function pickRandomWord() {
            const randomWordIndex = Math.floor(Math.random() * words.length);
            return words[randomWordIndex];
        }
        function updateMaskedWord() {
            let result = "";

            for (let i = 0; i < currentWord.length; i++) {
                const letter = currentWord[i];
                if (usedLetters.includes(letter)) {
                    result += letter;
                }
                else
                    result += "?";
            }
            setMaskedWordDisplay(result);
        }
        function handleLetterSelection(event: MouseEvent) {
            if (!(event.target instanceof HTMLButtonElement)) return;
            const btn = event.target;
            const letter = btn.textContent;

            if (currentGameStatus === gameStatuses.Playing) {
                if (btn) {
                    btn.disabled = true;
                }

                if (letter && letter.length > 0) {
                    const charLetter = letter[0];
                    if (!usedLetters.includes(charLetter)) {
                        usedLetters.push(charLetter);
                        setUsedLettersDisplay(usedLetters.join(""));
                    }
                }

                if (currentWord.includes(letter)) {
                    updateMaskedWord();
                } else {
                    setTriesRemaining(triesRemainingNumber - 1);
                }
                evaluateGameStatus();
            }
        }
        function endGame() {
            keyboardButtons.forEach(btn => btn.disabled = true);
            setAnswerDisplay(currentWord);
            switch (currentGameStatus) {
                case gameStatuses.Winning:
                    break;
                case gameStatuses.Start:
                    newGameMode();
                    break;
                case gameStatuses.GiveUp:
                    newGameMode();
                    break;
            }
            updateScoreDisplay();
            setGameMessageDisplay();
            setGameButtonsState(false);
        }

        function evaluateGameStatus() {
            if (maskedWord.textContent === currentWord) {
                currentGameStatus = gameStatuses.Winning;
                endGame();
            }
            else if (triesRemainingNumber < 1) {
                currentGameStatus = gameStatuses.Losing;
                endGame();
            }
            else {
                currentGameStatus = gameStatuses.Playing;
            }
            return currentGameStatus;
        }
        function calculatePoints() {
            let points = 0;
            let ecpoints = 0;

            if (triesRemainingNumber > 2 && currentGameStatus === gameStatuses.Winning) {
                ecpoints = 1;
            }
            switch (currentGameStatus) {
                case gameStatuses.Winning:
                    points = 1;
                    break;
                case gameStatuses.Losing:
                    points = -1;
                    break;
                case gameStatuses.GiveUp:
                    points = -2;
                    break;
                case gameStatuses.Start:
                    points = -(score.value);
                    break;
            }
            return points + ecpoints;
        }
        function calculateScore() {
            return Number(score.value) + calculatePoints();
        }
        function updateScoreDisplay() {
            score.value = calculateScore().toString();
        }
        function getGameMessage() {
            let msgText = `${currentWord.length}-letter word. Click on the keyboard below to choose a letter.`;
            const scoreValue = score.value;
            switch (currentGameStatus) {
                case gameStatuses.Start:
                    msgText = "Press 'New game' to begin playing.";
                    break;
                case gameStatuses.Winning:
                    msgText = `YOU WIN! Points earned this round: ${calculatePoints()} Total score: ${scoreValue}.`;
                    break;
                case gameStatuses.Losing:
                    msgText = `Game over. Word is: ${currentWord} Total score: ${scoreValue}.`;
                    break;
                case gameStatuses.GiveUp:
                    msgText = `No problem, you'll have another chance soon. Total score: ${scoreValue}.`;
                    break;
            }
            return msgText;
        }
        function gameGiveUp() {
            currentGameStatus = gameStatuses.GiveUp;
            endGame();
        }
        function gameReset() {
            currentGameStatus = gameStatuses.Start;
            endGame();
        }
        function newGameMode() {
            setGameButtonsState(true);
            setTriesRemaining(0);
            setMaskedWordDisplay("");
            usedLetters = [];
            setUsedLettersDisplay("");
            setAnswerDisplay("");
        }
        function setGameButtonsState(isGameActive: boolean) {
            btnNewGame.disabled = isGameActive;
            btnReset.disabled = !isGameActive;
            btnGiveUp.disabled = !isGameActive;
        }

        function setTriesRemaining(number: number) {
            triesRemainingNumber = number;
            triesRemaining.value = number.toString();
        }
        function setUsedLettersDisplay(letters: string) {
            usedLettersDisplay.value = letters;
        }
        function setMaskedWordDisplay(word: string) {
            maskedWord.textContent = word;
        }
        function setGameMessageDisplay() {
            msg.textContent = getGameMessage();
        }
        function setAnswerDisplay(word: string) {
            answer.value = word;
        }
    }
}
    Hangman.startGame();
