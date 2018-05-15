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
        public const char DOT = '*';
        private IGameBoard _gameBoard;
        private GameStatus _gameStatus;

        public void Start()
        {
            InitilizeGameStatus();
            MessageWriter.Greet();
            _gameBoard.Draw();
            Play();
        }

        public void Stop()
        {
            Environment.Exit(0);
        }

        public void Play()
        {
            var playerInput = _gameStatus.CurrentPlayer.Move();

            while (!_gameStatus.Finished)
            {
                var result = new PlayerInputParser(playerInput).Parse();

                switch (result.Status)
                {
                    case LastMoveStatus.AllPositionsOccupied:
                        FinishTheGame();
                        break;

                    case LastMoveStatus.Accepted:
                        _gameBoard.Update(result.Cordinate);
                        _gameBoard.Scan();
                        FinishTheGame();
                        MessageWriter.WriteToConsole(result.Message);
                        _gameBoard.Draw();
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

                playerInput = _gameStatus.CurrentPlayer.Move();
            }
        }

        private void InitilizeGameStatus()
        {
            _gameStatus = GameStatus.Instance;
            _gameStatus.Players = PlayerHelper.InitializePlayers();
            _gameStatus.CurrentPlayer = _gameStatus.Players.FirstOrDefault();
            _gameStatus.Finished = false;
            _gameStatus.Grid =
                new Grid(BoardHelper.InitializeGrid(Constants.GRID_HEIGHT, Constants.GRID_WIDTH, DOT));
            _gameBoard = new SquareBoard();
        }

        private void FinishTheGame()
        {
            if (_gameStatus.Finished)
            {
                MessageWriter.WriteToConsole(Constants.YOUWON);
                StopAndClose();
                return;
            }

            if (_gameStatus.Draw)
            {
                MessageWriter.WriteToConsole(Constants.ALLPOSITIONSOCCUPIED);
                StopAndClose();
            }
        }

        private void StopAndClose()
        {
            _gameBoard.Draw();
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