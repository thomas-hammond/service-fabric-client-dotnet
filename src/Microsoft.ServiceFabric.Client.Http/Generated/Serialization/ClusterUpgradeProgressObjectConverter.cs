// ------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License (MIT). See License.txt in the repo root for license information.
// ------------------------------------------------------------

namespace Microsoft.ServiceFabric.Client.Http.Serialization
{
    using System;
    using System.Collections.Generic;
    using Microsoft.ServiceFabric.Common;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    /// <summary>
    /// Converter for <see cref="ClusterUpgradeProgressObject" />.
    /// </summary>
    internal class ClusterUpgradeProgressObjectConverter
    {
        /// <summary>
        /// Deserializes the JSON representation of the object.
        /// </summary>
        /// <param name="reader">The <see cref="T: Newtonsoft.Json.JsonReader" /> to read from.</param>
        /// <returns>The object Value.</returns>
        internal static ClusterUpgradeProgressObject Deserialize(JsonReader reader)
        {
            return reader.Deserialize(GetFromJsonProperties);
        }

        /// <summary>
        /// Gets the object from Json properties.
        /// </summary>
        /// <param name="reader">The <see cref="T: Newtonsoft.Json.JsonReader" /> to read from, reader must be placed at first property.</param>
        /// <returns>The object Value.</returns>
        internal static ClusterUpgradeProgressObject GetFromJsonProperties(JsonReader reader)
        {
            var codeVersion = default(string);
            var configVersion = default(string);
            var upgradeDomains = default(IEnumerable<UpgradeDomainInfo>);
            var upgradeUnits = default(IEnumerable<UpgradeUnitInfo>);
            var upgradeState = default(UpgradeState?);
            var nextUpgradeDomain = default(string);
            var rollingUpgradeMode = default(UpgradeMode?);
            var upgradeDescription = default(ClusterUpgradeDescriptionObject);
            var upgradeDurationInMilliseconds = default(string);
            var upgradeDomainDurationInMilliseconds = default(string);
            var unhealthyEvaluations = default(IEnumerable<HealthEvaluationWrapper>);
            var currentUpgradeDomainProgress = default(CurrentUpgradeDomainProgressInfo);
            var currentUpgradeUnitsProgress = default(CurrentUpgradeUnitsProgressInfo);
            var startTimestampUtc = default(string);
            var failureTimestampUtc = default(string);
            var failureReason = default(FailureReason?);
            var upgradeDomainProgressAtFailure = default(FailedUpgradeDomainProgressObject);
            var isNodeByNode = default(bool?);

            do
            {
                var propName = reader.ReadPropertyName();
                if (string.Compare("CodeVersion", propName, StringComparison.OrdinalIgnoreCase) == 0)
                {
                    codeVersion = reader.ReadValueAsString();
                }
                else if (string.Compare("ConfigVersion", propName, StringComparison.OrdinalIgnoreCase) == 0)
                {
                    configVersion = reader.ReadValueAsString();
                }
                else if (string.Compare("UpgradeDomains", propName, StringComparison.OrdinalIgnoreCase) == 0)
                {
                    upgradeDomains = reader.ReadList(UpgradeDomainInfoConverter.Deserialize);
                }
                else if (string.Compare("UpgradeUnits", propName, StringComparison.OrdinalIgnoreCase) == 0)
                {
                    upgradeUnits = reader.ReadList(UpgradeUnitInfoConverter.Deserialize);
                }
                else if (string.Compare("UpgradeState", propName, StringComparison.OrdinalIgnoreCase) == 0)
                {
                    upgradeState = UpgradeStateConverter.Deserialize(reader);
                }
                else if (string.Compare("NextUpgradeDomain", propName, StringComparison.OrdinalIgnoreCase) == 0)
                {
                    nextUpgradeDomain = reader.ReadValueAsString();
                }
                else if (string.Compare("RollingUpgradeMode", propName, StringComparison.OrdinalIgnoreCase) == 0)
                {
                    rollingUpgradeMode = UpgradeModeConverter.Deserialize(reader);
                }
                else if (string.Compare("UpgradeDescription", propName, StringComparison.OrdinalIgnoreCase) == 0)
                {
                    upgradeDescription = ClusterUpgradeDescriptionObjectConverter.Deserialize(reader);
                }
                else if (string.Compare("UpgradeDurationInMilliseconds", propName, StringComparison.OrdinalIgnoreCase) == 0)
                {
                    upgradeDurationInMilliseconds = reader.ReadValueAsString();
                }
                else if (string.Compare("UpgradeDomainDurationInMilliseconds", propName, StringComparison.OrdinalIgnoreCase) == 0)
                {
                    upgradeDomainDurationInMilliseconds = reader.ReadValueAsString();
                }
                else if (string.Compare("UnhealthyEvaluations", propName, StringComparison.OrdinalIgnoreCase) == 0)
                {
                    unhealthyEvaluations = reader.ReadList(HealthEvaluationWrapperConverter.Deserialize);
                }
                else if (string.Compare("CurrentUpgradeDomainProgress", propName, StringComparison.OrdinalIgnoreCase) == 0)
                {
                    currentUpgradeDomainProgress = CurrentUpgradeDomainProgressInfoConverter.Deserialize(reader);
                }
                else if (string.Compare("CurrentUpgradeUnitsProgress", propName, StringComparison.OrdinalIgnoreCase) == 0)
                {
                    currentUpgradeUnitsProgress = CurrentUpgradeUnitsProgressInfoConverter.Deserialize(reader);
                }
                else if (string.Compare("StartTimestampUtc", propName, StringComparison.OrdinalIgnoreCase) == 0)
                {
                    startTimestampUtc = reader.ReadValueAsString();
                }
                else if (string.Compare("FailureTimestampUtc", propName, StringComparison.OrdinalIgnoreCase) == 0)
                {
                    failureTimestampUtc = reader.ReadValueAsString();
                }
                else if (string.Compare("FailureReason", propName, StringComparison.OrdinalIgnoreCase) == 0)
                {
                    failureReason = FailureReasonConverter.Deserialize(reader);
                }
                else if (string.Compare("UpgradeDomainProgressAtFailure", propName, StringComparison.OrdinalIgnoreCase) == 0)
                {
                    upgradeDomainProgressAtFailure = FailedUpgradeDomainProgressObjectConverter.Deserialize(reader);
                }
                else if (string.Compare("IsNodeByNode", propName, StringComparison.OrdinalIgnoreCase) == 0)
                {
                    isNodeByNode = reader.ReadValueAsBool();
                }
                else
                {
                    reader.SkipPropertyValue();
                }
            }
            while (reader.TokenType != JsonToken.EndObject);

            return new ClusterUpgradeProgressObject(
                codeVersion: codeVersion,
                configVersion: configVersion,
                upgradeDomains: upgradeDomains,
                upgradeUnits: upgradeUnits,
                upgradeState: upgradeState,
                nextUpgradeDomain: nextUpgradeDomain,
                rollingUpgradeMode: rollingUpgradeMode,
                upgradeDescription: upgradeDescription,
                upgradeDurationInMilliseconds: upgradeDurationInMilliseconds,
                upgradeDomainDurationInMilliseconds: upgradeDomainDurationInMilliseconds,
                unhealthyEvaluations: unhealthyEvaluations,
                currentUpgradeDomainProgress: currentUpgradeDomainProgress,
                currentUpgradeUnitsProgress: currentUpgradeUnitsProgress,
                startTimestampUtc: startTimestampUtc,
                failureTimestampUtc: failureTimestampUtc,
                failureReason: failureReason,
                upgradeDomainProgressAtFailure: upgradeDomainProgressAtFailure,
                isNodeByNode: isNodeByNode);
        }

        /// <summary>
        /// Serializes the object to JSON.
        /// </summary>
        /// <param name="writer">The <see cref="T: Newtonsoft.Json.JsonWriter" /> to write to.</param>
        /// <param name="obj">The object to serialize to JSON.</param>
        internal static void Serialize(JsonWriter writer, ClusterUpgradeProgressObject obj)
        {
            // Required properties are always serialized, optional properties are serialized when not null.
            writer.WriteStartObject();
            writer.WriteProperty(obj.UpgradeState, "UpgradeState", UpgradeStateConverter.Serialize);
            writer.WriteProperty(obj.RollingUpgradeMode, "RollingUpgradeMode", UpgradeModeConverter.Serialize);
            writer.WriteProperty(obj.FailureReason, "FailureReason", FailureReasonConverter.Serialize);
            if (obj.CodeVersion != null)
            {
                writer.WriteProperty(obj.CodeVersion, "CodeVersion", JsonWriterExtensions.WriteStringValue);
            }

            if (obj.ConfigVersion != null)
            {
                writer.WriteProperty(obj.ConfigVersion, "ConfigVersion", JsonWriterExtensions.WriteStringValue);
            }

            if (obj.UpgradeDomains != null)
            {
                writer.WriteEnumerableProperty(obj.UpgradeDomains, "UpgradeDomains", UpgradeDomainInfoConverter.Serialize);
            }

            if (obj.UpgradeUnits != null)
            {
                writer.WriteEnumerableProperty(obj.UpgradeUnits, "UpgradeUnits", UpgradeUnitInfoConverter.Serialize);
            }

            if (obj.NextUpgradeDomain != null)
            {
                writer.WriteProperty(obj.NextUpgradeDomain, "NextUpgradeDomain", JsonWriterExtensions.WriteStringValue);
            }

            if (obj.UpgradeDescription != null)
            {
                writer.WriteProperty(obj.UpgradeDescription, "UpgradeDescription", ClusterUpgradeDescriptionObjectConverter.Serialize);
            }

            if (obj.UpgradeDurationInMilliseconds != null)
            {
                writer.WriteProperty(obj.UpgradeDurationInMilliseconds, "UpgradeDurationInMilliseconds", JsonWriterExtensions.WriteStringValue);
            }

            if (obj.UpgradeDomainDurationInMilliseconds != null)
            {
                writer.WriteProperty(obj.UpgradeDomainDurationInMilliseconds, "UpgradeDomainDurationInMilliseconds", JsonWriterExtensions.WriteStringValue);
            }

            if (obj.UnhealthyEvaluations != null)
            {
                writer.WriteEnumerableProperty(obj.UnhealthyEvaluations, "UnhealthyEvaluations", HealthEvaluationWrapperConverter.Serialize);
            }

            if (obj.CurrentUpgradeDomainProgress != null)
            {
                writer.WriteProperty(obj.CurrentUpgradeDomainProgress, "CurrentUpgradeDomainProgress", CurrentUpgradeDomainProgressInfoConverter.Serialize);
            }

            if (obj.CurrentUpgradeUnitsProgress != null)
            {
                writer.WriteProperty(obj.CurrentUpgradeUnitsProgress, "CurrentUpgradeUnitsProgress", CurrentUpgradeUnitsProgressInfoConverter.Serialize);
            }

            if (obj.StartTimestampUtc != null)
            {
                writer.WriteProperty(obj.StartTimestampUtc, "StartTimestampUtc", JsonWriterExtensions.WriteStringValue);
            }

            if (obj.FailureTimestampUtc != null)
            {
                writer.WriteProperty(obj.FailureTimestampUtc, "FailureTimestampUtc", JsonWriterExtensions.WriteStringValue);
            }

            if (obj.UpgradeDomainProgressAtFailure != null)
            {
                writer.WriteProperty(obj.UpgradeDomainProgressAtFailure, "UpgradeDomainProgressAtFailure", FailedUpgradeDomainProgressObjectConverter.Serialize);
            }

            if (obj.IsNodeByNode != null)
            {
                writer.WriteProperty(obj.IsNodeByNode, "IsNodeByNode", JsonWriterExtensions.WriteBoolValue);
            }

            writer.WriteEndObject();
        }
    }
}
