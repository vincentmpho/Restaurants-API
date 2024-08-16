﻿using MediatR;

namespace Restaurants.Application.Commands.CreateRestaurant
{
    public class CreateRestaurantCommand : IRequest<Guid>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string HasDelivery { get; set; }

        public string ContactEmail { get; set; }
        public string ContactNumber { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string PostalCode { get; set; }
    }
}