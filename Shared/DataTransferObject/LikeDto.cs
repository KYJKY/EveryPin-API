﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObject;

public record LikeDto(int LikeId, int PostId, Guid UserId, DateTime? CreatedDate);
