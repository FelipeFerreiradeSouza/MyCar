﻿using MyCar.DTOs;
using MyCar.Models;
using System.Threading.Tasks;

namespace MyCar.Services.Interfaces
{
    public interface IEmailService
    {
        public Task CreateEmail(EmailModel emailModel);

        public EmailDTO CreateEmailBody(string emailType, UserModel userModel, int codeValidation);
    }
}
