﻿using Sales.Domain.Entities;

namespace Sales.Tests
{
    public class ItemTest
    {
        [Test]
        public void ValidarDescricaoPreenchida()
        {
            var item = new Item(0, null, 10);
            Assert.That(item.IsValid, Is.False);
        }
    }
}
