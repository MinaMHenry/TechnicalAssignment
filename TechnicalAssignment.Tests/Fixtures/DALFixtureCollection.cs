﻿using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace TechnicalAssignment.Tests.Fixtures
{
    [CollectionDefinition("DALFixture Collection")]
    public class DALFixtureCollection : ICollectionFixture<DALFixture>
    {
    }
}
