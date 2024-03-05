using Dapr;
using Microsoft.AspNetCore.Mvc;

namespace DaprShop.Recommendation.API.Controllers
{
	[ApiController]
	[Route("api/recommendations")]
	public class RecommendationController : ControllerBase
	{
		private const string PubsubName = "pubsub";
		private const string TopicNameOfShoppingCartItems = "daprshop.shoppingcart.items";

		[Topic(PubsubName, TopicNameOfShoppingCartItems)]
		[Route("products")]
		[HttpPost]
		public ActionResult AddProduct(ProductItemAddedToShoppingCartEvent productItemAddedToShoppingCartEvent)
		{
			Console.WriteLine($"New product has been added into shopping cart. Product Id: {productItemAddedToShoppingCartEvent.ProductId} User Id: {productItemAddedToShoppingCartEvent.UserId}");

			return Ok();
		}
	}
}
