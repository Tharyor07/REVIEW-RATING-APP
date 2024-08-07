﻿using System.ComponentModel.DataAnnotations;

namespace repository_pattern.DTO;

public record LoginUserDTO([EmailAddress]string Username, string Password);
