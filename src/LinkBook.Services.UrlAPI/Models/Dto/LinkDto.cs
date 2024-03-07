﻿namespace LinkBook.Services.UrlAPI.Models;

public class LinkDto
{
    public string Id { get; set; }
    public string UserId { get; set; }
    public string AliasUrl{ get; set; }
    public string OriginalUrl { get; set; }
    public string Tag { get; set; }
}
