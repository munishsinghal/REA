using NUnit.Framework;
using ToyRobot.Console;

namespace ToyRobot.Test
{
    public class RobotPlaceTests
    {
        private Game _game;
        private Robot _robot;
        [SetUp]
        public void Setup()
        {
            _game = new Game(5, 5);
            _robot = new Robot(_game);
        }

        [Test]
        public void InactiveRobot()
        {
            bool actual = _robot.Active;
            Location actualLocation = _robot.Location;
            Assert.IsFalse(actual, $"{actual} should be False");
            Assert.IsNull(actualLocation, $"{actual} should be Null");
        }

        [Test]
        public void InactiveRobotIgnoresCommands()
        {
            _robot.Move();
            Location actual = _robot.Location;
            Assert.IsNull(actual, $"{actual} should be Null");
        }

        [Test]
        public void ActiveRobot()
        {
            _robot.Place("PLACE 0,0,NORTH");
            bool actual = _robot.Active;
            int expectedPosX = 0;
            int expectedPosY = 0;
            Direction expectedDir = Direction.NORTH;
            int actualPosX = _robot.Location.X;
            int actualPosY = _robot.Location.Y;
            Direction actualDir = _robot.Direction;
            Assert.IsTrue(actual, $"{actual} should be True");
            Assert.AreEqual(actualPosX, expectedPosX, $"{actualPosX} should be the same as {expectedPosX}");
            Assert.AreEqual(actualPosY, expectedPosY, $"{actualPosY} should be the same as {expectedPosY}");
            Assert.AreEqual(actualDir, expectedDir, $"{actualDir} should be the same as {expectedDir}");
        }

        [Test]
        public void InvalidPlaceRobotOutOfBounds()
        {
            _robot.Place("PLACE 0,0,EAST1");
            bool actual = _robot.Active;
            Assert.IsFalse(actual, $"{actual} should be False");
            Assert.IsNull(_robot.Location, "Robot location should be null");
            Assert.AreEqual((int)_robot.Direction, -1, "Robot direction should be -1");
        }

        [Test]
        public void InvalidPlaceRobotDirection()
        {
            _robot.Place("PLACE 0,0,NORTH1");
            bool actual = _robot.Active;
            Assert.IsFalse(actual, $"{actual} should be False");
            Assert.IsNull(_robot.Location, "Robot location should be null");
            Assert.AreEqual((int)_robot.Direction, -1, "Robot direction should be -1");
        }

        [Test]
        public void ActiveRobotMoves()
        {
            Location posBefore = _robot.Location;
            _robot.Place("PLACE 0,0,NORTH");
            Location posAfter = _robot.Location;
            Assert.AreNotSame(posBefore, posAfter, $"{posAfter} should not be the same as {posBefore}");
        }
    }
}