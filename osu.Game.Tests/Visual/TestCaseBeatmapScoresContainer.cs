﻿// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Shapes;
using osu.Framework.MathUtils;
using osu.Game.Graphics;
using osu.Game.Overlays.BeatmapSet.Scores;
using osu.Game.Rulesets.Mods;
using osu.Game.Rulesets.Osu.Mods;
using osu.Game.Rulesets.Scoring;
using osu.Game.Users;
using System.Collections.Generic;
using osu.Framework.Graphics.Containers;
using osu.Game.Online.API.Requests.Responses;
using osu.Game.Scoring;
using NUnit.Framework;

namespace osu.Game.Tests.Visual
{
    [Description("in BeatmapOverlay")]
    public class TestCaseBeatmapScoresContainer : OsuTestCase
    {
        private readonly Box background;

        public TestCaseBeatmapScoresContainer()
        {
            ScoresContainer scoresContainer;

            Child = new Container
            {
                Anchor = Anchor.TopCentre,
                Origin = Anchor.TopCentre,
                AutoSizeAxes = Axes.Y,
                RelativeSizeAxes = Axes.X,
                Width = 0.8f,
                Children = new Drawable[]
                {
                    background = new Box { RelativeSizeAxes = Axes.Both },
                    scoresContainer = new ScoresContainer(),
                }
            };

            IEnumerable<APIScoreInfo> scores = new[]
            {
                new APIScoreInfo
                {
                    User = new User
                    {
                        Id = 6602580,
                        Username = @"waaiiru",
                        Country = new Country
                        {
                            FullName = @"Spain",
                            FlagName = @"ES",
                        },
                    },
                    Mods = new Mod[]
                    {
                        new OsuModDoubleTime(),
                        new OsuModHidden(),
                        new OsuModFlashlight(),
                        new OsuModHardRock(),
                    },
                    Rank = ScoreRank.XH,
                    PP = 200,
                    MaxCombo = 1234,
                    TotalScore = 1234567890,
                    Accuracy = 1,
                },
                new APIScoreInfo
                {
                    User = new User
                    {
                        Id = 4608074,
                        Username = @"Skycries",
                        Country = new Country
                        {
                            FullName = @"Brazil",
                            FlagName = @"BR",
                        },
                    },
                    Mods = new Mod[]
                    {
                        new OsuModDoubleTime(),
                        new OsuModHidden(),
                        new OsuModFlashlight(),
                    },
                    Rank = ScoreRank.S,
                    PP = 190,
                    MaxCombo = 1234,
                    TotalScore = 1234789,
                    Accuracy = 0.9997,
                },
                new APIScoreInfo
                {
                    User = new User
                    {
                        Id = 1014222,
                        Username = @"eLy",
                        Country = new Country
                        {
                            FullName = @"Japan",
                            FlagName = @"JP",
                        },
                    },
                    Mods = new Mod[]
                    {
                        new OsuModDoubleTime(),
                        new OsuModHidden(),
                    },
                    Rank = ScoreRank.B,
                    PP = 180,
                    MaxCombo = 1234,
                    TotalScore = 12345678,
                    Accuracy = 0.9854,
                },
                new APIScoreInfo
                {
                    User = new User
                    {
                        Id = 1541390,
                        Username = @"Toukai",
                        Country = new Country
                        {
                            FullName = @"Canada",
                            FlagName = @"CA",
                        },
                    },
                    Mods = new Mod[]
                    {
                        new OsuModDoubleTime(),
                    },
                    Rank = ScoreRank.C,
                    PP = 170,
                    MaxCombo = 1234,
                    TotalScore = 1234567,
                    Accuracy = 0.8765,
                },
                new APIScoreInfo
                {
                    User = new User
                    {
                        Id = 7151382,
                        Username = @"Mayuri Hana",
                        Country = new Country
                        {
                            FullName = @"Thailand",
                            FlagName = @"TH",
                        },
                    },
                    Rank = ScoreRank.F,
                    PP = 160,
                    MaxCombo = 1234,
                    TotalScore = 123456,
                    Accuracy = 0.6543,
                },
            };

            foreach (var s in scores)
            {
                s.Statistics.Add(HitResult.Great, RNG.Next(2000));
                s.Statistics.Add(HitResult.Good, RNG.Next(2000));
                s.Statistics.Add(HitResult.Meh, RNG.Next(2000));
                s.Statistics.Add(HitResult.Miss, RNG.Next(2000));
            }

            scoresContainer.Scores = scores;
        }

        [BackgroundDependencyLoader]
        private void load(OsuColour colours)
        {
            background.Colour = colours.Gray2;
        }
    }
}
