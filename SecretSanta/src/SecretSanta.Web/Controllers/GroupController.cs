using SecretSanta.Web.Api;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace SecretSanta.Web.Controllers
{
    public class GroupController : Controller
    {
        public GroupController(IHttpClientFactory clientFactory)
        {
            if (clientFactory is null)
            {
                throw new System.ArgumentNullException(nameof(clientFactory));
            }

            ClientFactory = clientFactory;
        }

        public IHttpClientFactory ClientFactory { get; }

        // GET: Group
        public async Task<ActionResult> Index()
        {
            HttpClient httpClient = ClientFactory.CreateClient("BlogApi");

            var client = new GroupClient(httpClient);
            ICollection<Group> groups = await client.GetAllAsync();
            return View(groups);
        }
    }
}