using ATM_Machine.Models;

namespace ATM_Machine.Tests
{
    public class MoneyVaultTests
    {
        MoneyVault _moneyVault;
        int _maxNumberBanknotePerOperation = 50;
        [SetUp]
        public void Setup()
        {
            List<BanknoteCassette> banknoteCassettes = new List<BanknoteCassette>
            {                
                new BanknoteCassette
                    (
                        denomination: 100,
                        maxNumberOfBanknotes: 100,
                        numberOfBanknotes: 50
                    ),
                new BanknoteCassette
                    (
                        denomination: 500,
                        maxNumberOfBanknotes: 100,
                        numberOfBanknotes: 50
                    )
            };
            _moneyVault = new MoneyVault(banknoteCassettes, _maxNumberBanknotePerOperation);
        }
        [Test]
        public void AddMoney_Success()
        {
            // Arrange
            List<Banknotes> list = new List<Banknotes>
                    {
                        new Banknotes(100, 10),
                        new Banknotes(500, 10)
                    };
            // Act
            var result = _moneyVault.PutBanknotes(list);
            // Assert
            Assert.IsTrue(result);
        }
        [Test]
        public void AddMoney_OverflowStorage()
        {
            // Arrange
            List<Banknotes> list = new List<Banknotes>
                    {
                        new Banknotes(100, 50),
                        new Banknotes(500, 50)
                    };
            // Act
            _moneyVault.PutBanknotes(list);
            _moneyVault.PutBanknotes(list);
            var result = _moneyVault.PutBanknotes(list);
        }
        [Test]
        public void AddMoney_ReceiverOverflow()
        {
            // Arrange
            List<Banknotes> list = new List<Banknotes>
                    {
                        new Banknotes(100, 150),
                        new Banknotes(500, 150)
                    };
            // Act
            var result = _moneyVault.PutBanknotes(list);
            // Assert
            Assert.IsFalse(result);
        }
        [Test]
        public void WithdrawMoney_Success()
        {
            // Arrange
            List<Banknotes> list = new List<Banknotes>
                    {
                        new Banknotes(100, 10),
                        new Banknotes(500, 10)
                    };
            // Act
            var result = _moneyVault.WithdrawBanknotes(list);
            // Assert
            Assert.IsTrue(result);
        }
        [Test]
        public void WithdrawMoney_LowStorage()
        {
            // Arrange
            List<Banknotes> list = new List<Banknotes>
                    {
                        new Banknotes(100, 50),
                        new Banknotes(500, 50)
                    };
            // Act
            _moneyVault.WithdrawBanknotes(list);
            _moneyVault.WithdrawBanknotes(list);
            var result = _moneyVault.WithdrawBanknotes(list);
            // Assert
            Assert.IsFalse(result);
        }
        [Test]
        public void WithdrawMoney_ReceiverOverflow()
        {
            // Arrange
            List<Banknotes> list = new List<Banknotes>
                    {
                        new Banknotes(100, 150),
                        new Banknotes(500, 150)
                    };
            // Act
            var result = _moneyVault.WithdrawBanknotes(list);
            // Assert
            Assert.IsFalse(result);
        }
    }
}