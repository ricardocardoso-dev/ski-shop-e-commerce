using System.Collections.Generic;
using Xunit;
using api.Entities;
using NuGet.Frameworks;

namespace Tests;

public class BasketTests
{
    [Fact]
    public void Should_Not_Add_Duplicated_Product()
    {
        // Arrange
        var initialBasketItem = new BasketItem { ProductId = 1, Quantity = 5 };
        var basket = new Basket { Items = new List<BasketItem> { initialBasketItem } };
        var product = new Product { Id = 1 };

        // Act
        basket.AddItem(product, 10);

        // Assert
        Assert.Single(basket.Items);
    }

    [Fact]
    public void Should_Add_Quantity()
    {
        // Arrange
        var initialQuantity = 2;
        var productId = 1;
        var addingQuantity = 3;

        var initialBasketItem = new BasketItem { ProductId = productId, Quantity = initialQuantity };
        var basket = new Basket { Items = new List<BasketItem> { initialBasketItem } };
        var product = new Product { Id = productId };

        // Act
        basket.AddItem(product, addingQuantity);

        // Assert
        Assert.Equal(initialQuantity + addingQuantity, basket.Items[0].Quantity);
    }


    [Fact]
    public void Should_Remove_Quantity()
    {
        //Arrange
        var initialQuantity = 5;
        var productId = 1;
        var removingQuantity = initialQuantity - 1;

        var initialBasketItem = new BasketItem { ProductId = productId, Quantity = initialQuantity };
        var basket = new Basket { Items = new List<BasketItem> { initialBasketItem } };

        //Act
        basket.RemoveItem(productId, removingQuantity);

        //Assert
        Assert.Equal(initialQuantity - removingQuantity, basket.Items[0].Quantity);
    }

    [Fact]
    public void Should_Remove_BasketItem_Without_Quantity()
    {
        var initialQuantity = 5;
        var productId = 1;
        var removingQuantity = initialQuantity;

        var initialBasketItem = new BasketItem { ProductId = productId, Quantity = initialQuantity };
        var basket = new Basket { Items = new List<BasketItem> { initialBasketItem } };;

        basket.RemoveItem(productId, removingQuantity);

        var resultItem = new BasketItem();
        resultItem = basket.Items.Find(x => x.ProductId == productId);

        Assert.Null(resultItem);
    }

    [Fact]
    public void Should_Not_Remove_Quantity_Greater_Than_Initial()
    {
        var initialQuantity = 5;
        var productId = 1;
        var removingQuantity = initialQuantity * 2;

        var initialBasketItem = new BasketItem { ProductId = productId, Quantity = initialQuantity };
        var basket = new Basket { Items = new List<BasketItem> { initialBasketItem } };

        basket.RemoveItem(productId, removingQuantity);

        bool result = basket.Items[0].Quantity < initialQuantity;
        Assert.False(result);
    }

}
