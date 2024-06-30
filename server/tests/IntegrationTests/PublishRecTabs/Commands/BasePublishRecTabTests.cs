using System;
using Application.Features.PublishRecTab.Requests.Commands;
using Domain;
using Domain.Constants;
using Domain.Enums;

namespace IntegrationTests.PublishRecTabs.Commands
{
    public class BasePublishRecTabTests : TestBase
    {
        protected CreatePublishRecTabCommand GetValidCreateTabCommand(int userId)
        {
            return new CreatePublishRecTabCommand
            {
                UserId = userId,
                TestType = UserTestType.Ege,
                Sogl = true,
                SostType = true,
                Advantage = true,
                Individ = 10,
                RusPoint = 10,
                ObshPoint = 10,
                KpPoint = 10,
                SpecPoint = 10,
                ForeignLanguagePoint = 10,
                GpPoint = 10,
                HistoryPoint = 10,
                OkpPoint = 10,
                TgpPoint = 0,
                UpPoint = 10,
                BakOfoGp = true,
                BakOfoUp = true,
                BakZfoGp = false,
                BakZfoUp = false,
                BakOzfoGp = false,
                BakOzfoUp = false,
                SpecOfoSd = false,
                MagOfoPo = false,
                MagZfoPo = false,
                MagOfoTp = false,
                MagZfoTp = false,
                AspOfoGp = false,
                AspOfoUgp = false,
                IsPublished = false,
                Comment = "Comment",
            };
        }

        protected UpdatePublishRecTabCommand GetValidUpdateTabCommand(int userId)
        {
            return new UpdatePublishRecTabCommand
            {
                UserId = userId,
                TestType = UserTestType.VI,
                Sogl = false,
                SostType = false,
                Advantage = false,
                Individ = 20,
                RusPoint = 20,
                ObshPoint = 20,
                KpPoint = 20,
                SpecPoint = 20,
                ForeignLanguagePoint = 20,
                GpPoint = 20,
                HistoryPoint = 20,
                OkpPoint = 20,
                TgpPoint = 0,
                UpPoint = 20,
                BakOfoGp = false,
                BakOfoUp = false,
                BakZfoGp = false,
                BakZfoUp = false,
                BakOzfoGp = false,
                BakOzfoUp = false,
                SpecOfoSd = false,
                MagOfoPo = false,
                MagZfoPo = true,
                MagOfoTp = true,
                MagZfoTp = false,
                AspOfoGp = false,
                AspOfoUgp = false,
                IsPublished = false,
                Comment = "Comment updated",
            };
        }
    }
}