﻿using CoffeeShop.Models;
using CoffeeShop.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CoffeeShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BeanVarietyController : ControllerBase
    {
        private readonly IBeanVarietyRepository _beanVarietyRepository;

        public BeanVarietyController(IBeanVarietyRepository beanVarietyRepository)
        {
            _beanVarietyRepository = beanVarietyRepository;
        }

        // GET: api/<BeanVarietyController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_beanVarietyRepository.GetAll());
        }

        // GET api/<BeanVarietyController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var variety = _beanVarietyRepository.Get(id);
            if (variety == null)
            {
                return NotFound();
            }
            return Ok(variety);
        }

        // POST api/<BeanVarietyController>
        [HttpPost]
        public IActionResult Post(BeanVariety beanVariety)
        {
            _beanVarietyRepository.Add(beanVariety);
            return CreatedAtAction("Get", new { id = beanVariety.Id }, beanVariety);
        }


        // PUT api/<BeanVarietyController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, BeanVariety beanVariety)
        {
            if (id != beanVariety.Id)
            {
                return BadRequest();
            }

            _beanVarietyRepository.Update(beanVariety);
            return NoContent();
        }
        // DELETE api/<BeanVarietyController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _beanVarietyRepository.Delete(id);
            return NoContent();
        }
    }
}
