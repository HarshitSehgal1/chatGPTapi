﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpenAI_API.Completions;
using OpenAI_API;
namespace OpenAIApp.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OpenAI : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetData(string input)
        {
            string apiKey = "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";
            string response = "";
            OpenAIAPI openai = new OpenAIAPI(apiKey);
            CompletionRequest completion = new CompletionRequest();
            completion.Prompt = input;
            completion.Model = "text-davinci-003";
            completion.MaxTokens = 200;
            var output = await openai.Completions.CreateCompletionAsync(completion);
            if (output != null)
            {
                foreach (var item in output.Completions)
                {
                    response = item.Text;
                }
                return Ok(response);
            }
            else
            {
                return BadRequest("Not found");
            }
        }
    }
}