﻿namespace Organization_Service.Dtos;

public class UpdateOrganizationAdminDto
{
    public string Name { get; set; } = "";
    public string EmailAddress { get; set; } = "";
    public Boolean IsArchived { get; set; } = false;
}