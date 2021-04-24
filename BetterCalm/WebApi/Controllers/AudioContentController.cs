﻿using AdapterExceptions;
using AdapterInterface;
using BetterCalm.WebApi.Controllers;
using Microsoft.AspNetCore.Mvc;
using Model.In;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    public class AudioContentController : BetterCalmControllerBase
    {
        private readonly IAudioContentLogicAdapter audioContentLogicAdapter;

        public AudioContentController(IAudioContentLogicAdapter audioContentLogicAdapter)
        {
            this.audioContentLogicAdapter = audioContentLogicAdapter;
        }

        [HttpGet("{id}", Name = "GetAudioContentById")]
        public IActionResult Get(int audioContentId)
        {
            try
            {
                return Ok(audioContentLogicAdapter.GetById(audioContentId));
            }
            catch (NullObjectMappingException e)
            {
                return NotFound(e);
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] AudioContentModel audioContentModel)
        {
            var audioContentCreated = audioContentLogicAdapter.Add(audioContentModel);
            return CreatedAtRoute("GetAudioContentById", audioContentCreated.Id, audioContentCreated);
        }

        [HttpDelete("{audioContentId}")]
        public IActionResult DeleteById(int audioContentId)
        {
            audioContentLogicAdapter.DeleteById(audioContentId);
            return NoContent();
        }

        [HttpPut("{audioContentId}")]
        public IActionResult Update(int audioContentId, AudioContentModel audioContentModel)
        {
            audioContentLogicAdapter.UpdateById(audioContentId, audioContentModel);
            return NoContent();
        }
    }
}