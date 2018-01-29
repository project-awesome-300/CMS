﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CMS.Dtos
{
    public class EventDto
    {
        public int EventId { get; set; }

        public string Name { get; set; }

        public int Priority { get; set; }

        public string Details { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public int EventCatId { get; set; }

        public int LocationId { get; set; }

        public int OrganiserId { get; set; }

        public EventCategoryDto AssociatedEventCat { get; set; }

        public LocationDto AssociatedLocation { get; set; }

        public OrganiserDto AssociatedOrganiser { get; set; }





    }
}