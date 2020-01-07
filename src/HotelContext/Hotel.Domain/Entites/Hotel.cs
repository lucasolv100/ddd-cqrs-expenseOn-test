using System;
using System.Collections.Generic;
using Flunt.Validations;
using Hotel.Domain.Core.Entities;
using Hotel.Domain.ValueObjects;

namespace Hotel.Domain.Entites
{
    public class Hotel : Entity
    {
        public Hotel(string name, string description, double rating, Address address, string features)
        {
            Name = name;
            Description = description;
            Rating = rating;
            Address = address;
            Features = features;
            CreateDate = DateTime.Now;

            Validations();
        }

        private Hotel() { }

        //Está modelado em inglês na codificação apenas por costume para evitar o famozo... "GetByAno" rs
        // Nos arquivos de configuração na camada DATA será feito a conversão para português.
        //Esta entidade está usando a abordagem de desenvolvimento code-first voltada ao problema em questão que deve ser resolvido

        public string Name { get; private set; }
        public string Description { get; private set; }
        public double Rating { get; private set; }
        public Address Address { get; private set; }
        public string Features { get; private set; }


        //Algumas validações, como não está especificado estou considerando o que acho que seria o correto.
        public void Validations()
        {
            AddNotifications(
                new Contract()
                .Requires()
                .IsNotNullOrEmpty(Name, "Hotel.Name", "O nome do hotel é obrigatório")
                .IsNotNullOrEmpty(Description, "Hotel.Description", "A descrição do hotel é obrigatória")
            );
        }

        public void UpdateHotel(
            string name, string description, double rating, Address address, string features
        )
        {
            Name = name;
            Description = description;
            Rating = rating;
            Address = address;
            Features = features;
            EditDate = DateTime.Now;

            Validations();
        }
        public void DeleteHotel()
        {
            EditDate = DateTime.Now;
            DeleteDate = DateTime.Now;
        }
    }
}