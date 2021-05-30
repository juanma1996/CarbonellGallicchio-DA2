using AdapterInterface;
using BetterCalm.WebApi.Controllers;

namespace WebApi.Controllers
{
    public class VideoContentController : BetterCalmControllerBase
    {
        private readonly IVideoContentLogicAdapter videooContentLogicAdapter;

        public VideoContentController(IVideoContentLogicAdapter videooContentLogicAdapter)
        {
            this.videooContentLogicAdapter = videooContentLogicAdapter;
        }
        public object Get(int videoContentId)
        {
            return Ok(videooContentLogicAdapter.GetById(videoContentId));
        }
    }
}
