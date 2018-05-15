using System;
using System.Linq;
using TicTacToe.Board;
using TicTacToe.Player;
using TicTacToeGame.Game;
using TicTacToeGame.GameBoard;

namespace TicTacToe.Game
{
    public class Game : IGame
    {
        private GameStatus _gameStatus;
        private IGameBoard _gameBoard;
        public const char DOT = '*';

        public void Start()
        {
            InitilizeGameStatus();
            MessageWriter.Greet();
            this._gameBoard.Draw();
            Play();
        }

        private void InitilizeGameStatus()
        {
            this._gameStatus = GameStatus.Instance;
            this._gameStatus.Players = PlayerHelper.InitializePlayers();
            this._gameStatus.CurrentPlayer = this._gameStatus.Players.FirstOrDefault();
            this._gameStatus.Finished = false;
            this._gameStatus.Grid =
                new Grid(BoardHelper.InitializeGrid(Constants.GRID_HEIGHT, Constants.GRID_WIDTH, DOT));
            this._gameBoard = new SquareBoard();
        }

        public void Stop()
        {
            Environment.Exit(0);
        }

        public void Play()
        {
            var playerInput = this._gameStatus.CurrentPlayer.Move();

            while (!this._gameStatus.Finished)
            {
                var result = new PlayerInputParser(playerInput).Parse();

                switch (result.Status)
                {
                    case LastMoveStatus.AllPositionsOccupied:
                        FinishTheGame();
                        break;

                    case LastMoveStatus.Accepted:
                        this._gameBoard.Update(result.Cordinate);
                        this._gameBoard.Scan();
                        FinishTheGame();
                        MessageWriter.WriteToConsole(result.Message);
                        this._gameBoard.Draw();
                        SwitchPlayer();
                        break;

                    case LastMoveStatus.InvalidCordinates:
                        MessageWriter.WriteToConsole(result.Message);
                        break;

                    case LastMoveStatus.PositionOccupied:
                        MessageWriter.WriteToConsole(Constants.POSITIONOCCUPIED);
                        break;

                    case LastMoveStatus.Skipped:
                        SwitchPlayer();
                        break;
                }

                playerInput = this._gameStatus.CurrentPlayer.Move();
            }
        }

        private void FinishTheGame()
        {
            if (this._gameStatus.Finished)
            {
                MessageWriter.WriteToConsole(Constants.YOUWON);
                StopAndClose();
            }
            if (this._gameStatus.Draw)
            {
                MessageWriter.WriteToConsole(Constants.ALLPOSITIONSOCCUPIED);
                StopAndClose();
            }        
        }

        private void StopAndClose()
        {
            this._gameBoard.Draw();
            Console.ReadLine();
            Stop();
        }

        private static void SwitchPlayer()
        {
            GameStatus.Instance.CurrentPlayer =
                GameStatus.Instance.Players.Single(x => x.Symbol != GameStatus.Instance.CurrentPlayer.Symbol);
        }
    }
}
