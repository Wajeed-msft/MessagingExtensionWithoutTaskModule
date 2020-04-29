// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using AdaptiveCards;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Builder.Teams;
using Microsoft.Bot.Schema;
using Microsoft.Bot.Schema.Teams;
using Newtonsoft.Json.Linq;

namespace Microsoft.BotBuilderSamples.Bots
{
    public class TeamsMessagingExtensionsActionBot : TeamsActivityHandler
    {

        protected override async Task OnMessageActivityAsync(ITurnContext<IMessageActivity> turnContext, CancellationToken cancellationToken)
        {
            // This is a regular text message.
            await turnContext.SendActivityAsync(MessageFactory.Text($"Hello from the TeamsMessagingExtensionsActionPreviewBot."), cancellationToken);
        }

        //public override async Task OnTurnAsync(ITurnContext turnContext, CancellationToken cancellationToken = default)
        //{
        //    if(turnContext.Activity.Name == "composeExtension/submitAction")
        //    {
        //        var card = new HeroCard
        //        {
        //            Title = "foo",
        //            Subtitle = "subtitle",
        //            Text = "bar"
        //        };

        //        var attachments = new List<MessagingExtensionAttachment>();
        //        attachments.Add(new MessagingExtensionAttachment
        //        {
        //            Content = card,
        //            ContentType = HeroCard.ContentType,
        //            Preview = card.ToAttachment(),
        //        });

        //        var activity = new Activity
        //        {
        //            Type = ActivityTypesEx.InvokeResponse,
        //            Value = new InvokeResponse
        //            {
        //                Status = (int)HttpStatusCode.OK,
        //                Body = new MessagingExtensionActionResponse
        //                {
        //                    ComposeExtension = new MessagingExtensionResult
        //                    {
        //                        AttachmentLayout = "list",
        //                        Type = "result",
        //                        Attachments = attachments
        //                    },
        //                }
        //            }
        //        };

        //        await turnContext.SendActivityAsync(activity, cancellationToken: cancellationToken);
        //    }
        //}

        protected override async Task<MessagingExtensionActionResponse> OnTeamsMessagingExtensionSubmitActionAsync(ITurnContext<IInvokeActivity> turnContext, MessagingExtensionAction action, CancellationToken cancellationToken)
        {
            var card = new HeroCard
            {
                Title = "foo",
                Subtitle = "subtitle",
                Text = "bar"
            };

            var attachments = new List<MessagingExtensionAttachment>();
            attachments.Add(new MessagingExtensionAttachment
            {
                Content = card,
                ContentType = HeroCard.ContentType,
                Preview = card.ToAttachment(),
            });

            return new MessagingExtensionActionResponse
            {
                ComposeExtension = new MessagingExtensionResult
                {
                    AttachmentLayout = "list",
                    Type = "result",
                    Attachments = attachments
                },
            };
        }
    }
}
