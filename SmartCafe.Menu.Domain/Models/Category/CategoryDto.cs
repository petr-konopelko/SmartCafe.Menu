﻿namespace SmartCafe.Menu.Domain.Models.Category;

public class CategoryDto
{
    public Guid Id { get; set; }

    public required string Name { get; set; }

    public int Priority {  get; set; }
}
