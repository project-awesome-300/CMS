﻿using System;
using System.Linq;
using System.Web.Http;
using AutoMapper;
using CMS.Dtos;
using CMS.Models.CMSModel;

namespace CMS.Controllers.API
{
    public class EventCategoriesController : ApiController
    {
        private CmsContext _cms;

        public EventCategoriesController()
        {
            _cms = new CmsContext();
        }

        // Get /api/eventCategorys
        public IHttpActionResult GetEventCategories()
        {
            var eventCategorysQuery = _cms.EventCategories;

            var eventCategoryDtos = eventCategorysQuery
                .ToList()
                .Select(Mapper.Map<EventCategory, EventCategoryDto>);

            return Ok(eventCategoryDtos);
        }

        // Get /api/eventCategory/1
        public IHttpActionResult GetEventCategory(int id)
        {
            var eventCategory = _cms.EventCategories.SingleOrDefault(d => d.EventCategoryId == id);

            if (eventCategory == null)
                return NotFound();

            return Ok(Mapper.Map<EventCategory, EventCategoryDto>(eventCategory));
        }

        // Post /api/eventCategory
        [HttpPost]
        public IHttpActionResult CreateEventCategory(EventCategoryDto eventCategoryDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var eventCategory = Mapper.Map<EventCategoryDto, EventCategory>(eventCategoryDto);
            _cms.EventCategories.Add(eventCategory);
            _cms.SaveChanges();

            eventCategoryDto.EventCategoryId = eventCategory.EventCategoryId;

            return Created(new Uri(Request.RequestUri + "/" + eventCategory.EventCategoryId), eventCategoryDto);
        }

        //  Put /api/eventCategorys/1
        [HttpPut]
        public IHttpActionResult UpdateEventCategory(int id, EventCategoryDto eventCategoryDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var eventCategoryInDb = _cms.EventCategories.SingleOrDefault(d => d.EventCategoryId == id);

            if (eventCategoryInDb == null)
                return NotFound();

            Mapper.Map(eventCategoryDto, eventCategoryInDb);

            _cms.SaveChanges();

            return Ok();
        }

        //  Delete /api/eventCategorys/1
        [HttpDelete]
        public IHttpActionResult DeleteEventCategory(int id)
        {
            var eventCategoryInDb = _cms.EventCategories.SingleOrDefault(d => d.EventCategoryId == id);

            if (eventCategoryInDb == null)
                return NotFound();

            _cms.EventCategories.Remove(eventCategoryInDb);
            _cms.SaveChanges();

            return Ok();
        }
    }
}