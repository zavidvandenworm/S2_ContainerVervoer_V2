using ContainerTransport;

namespace Tests
{
    [TestFixture]
    public class ShipTests
    {
        [Test]
        public void Constructor_ShouldInitializeShipWithCorrectDimensions()
        {
            // Arrange
            var width = 5;
            var height = 3;

            // Act
            var ship = new Ship(height, width);

            // Assert
            Assert.That(ship.Width, Is.EqualTo(width));
            Assert.That(ship.Height, Is.EqualTo(height));
        }

        [Test]
        public void Constructor_ShouldInitializeShipWithCorrectNumberOfStacks()
        {
            // Arrange
            var width = 3;
            var height = 2;
            var expectedStackCount = width * height;

            // Act
            var ship = new Ship(height, width);

            // Assert
            Assert.That(ship.Stacks.Count, Is.EqualTo(expectedStackCount));
        }

        [Test]
        public void TryGetStackAt_ShouldReturnTrueAndValidStackForValidCoordinates()
        {
            // Arrange
            var width = 3;
            var height = 2;
            var ship = new Ship(height, width);
            var validX = 1;
            var validY = 0;

            // Act
            var result = ship.TryGetStackAt(validX, validY, out var stack);

            // Assert
            Assert.IsTrue(result);
            Assert.IsNotNull(stack);
            Assert.That(stack.X, Is.EqualTo(validX));
            Assert.That(stack.Y, Is.EqualTo(validY));
        }

        [Test]
        public void TryGetStackAt_ShouldReturnFalseAndNullForInvalidCoordinates()
        {
            // Arrange
            var width = 3;
            var height = 2;
            var ship = new Ship(height, width);
            var invalidX = 5;
            var invalidY = 10;

            // Act
            var result = ship.TryGetStackAt(invalidX, invalidY, out var stack);

            // Assert
            Assert.IsFalse(result);
            Assert.IsNull(stack);
        }
    }
}