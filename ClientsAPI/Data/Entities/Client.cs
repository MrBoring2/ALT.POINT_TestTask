

using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using ClientsAPI.Models.Enums;

namespace ClientsAPI.Data.Entities
{
    public partial class Client : BaseEntity
    {
        public Client()
        {
            if (Id == Guid.Empty)
            {
                Id = Guid.NewGuid();
            }
            if (CreatedAt == DateTime.MinValue)
            {
                CreatedAt = DateTime.Now;
                UpdatedAt = CreatedAt;
            }
        }

        private Client(Guid id, string name, string surname, string patronymic, DateTime dob, List<Child> children,
            List<Document> documentIds, Passport passport, Address livingAddress, Address regAddress, List<Job> jobs,
            decimal? curWorkExp, EducationTypeEnum typeEducation, decimal? monIncome, decimal? monExpenses,
            List<Communication> communications, DateTime createdAt, DateTime updatedAt, DateTime? deletedAt)
        {
            Id = id;
            Name = name;
            Surname = surname;
            Patronymic = patronymic;
            Dob = dob;
            Children = children;
            DocumentIds = documentIds;
            Passport = passport;
            LivingAddress = livingAddress;
            RegAddress = regAddress;
            Jobs = jobs;
            CurWorkExp = curWorkExp;
            TypeEducation = typeEducation;
            MonIncome = monIncome;
            MonExpenses = monExpenses;
            Communications = communications;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
            DeletedAt = deletedAt;
        }

        public Guid Id { get; protected set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public DateTime Dob { get; set; }
        public List<Child> Children { get; set; }
        public List<Document> DocumentIds { get; set; }
        public Passport Passport { get; set; }
        public Address LivingAddress { get; set; }
        public Address RegAddress { get; set; }
        public List<Job> Jobs { get; set; }
        public decimal? CurWorkExp { get; set; }


        public EducationTypeEnum TypeEducation { get; set; }
        public decimal? MonIncome { get; set; }
        public decimal? MonExpenses { get; set; }
        public List<Communication> Communications { get; set; }
        public DateTime CreatedAt { get; protected set; }
        public DateTime UpdatedAt { get; protected set; }
        public DateTime? DeletedAt { get; protected set; }
        public string FullName
        {
            get => $"{Surname} {Name} {Patronymic}";
        }



        public void Delete()
        {
            DeletedAt = DateTime.Now;
        }
        public void Update()
        {
            UpdatedAt = DateTime.Now;
        }
        public Client Copy()
        {
            return new Client(Id, Name, Surname, Patronymic, Dob, Children,
                              DocumentIds, Passport, LivingAddress, RegAddress, Jobs, CurWorkExp,
                              TypeEducation, MonIncome, MonExpenses, Communications, CreatedAt,
                              UpdatedAt, DeletedAt);
        }
    }
}