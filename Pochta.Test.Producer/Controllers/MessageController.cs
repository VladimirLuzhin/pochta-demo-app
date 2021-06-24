using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Pochta.Test.Controllers.Dto;
using Pochta.Test.Producer.Application.Message;

namespace Pochta.Test.Controllers
{
    [ApiController]
    [Route("/api/v1/messages")]
    public class MessageController : ControllerBase
    {
        private readonly MessageService _messageService;

        public MessageController(MessageService messageService)
        {
            _messageService = messageService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateNewMessageAsync(MessageDto messageDto)
        {
            await _messageService.SaveMessageAsync(messageDto.Text);
            return Ok();
        }
    }
}