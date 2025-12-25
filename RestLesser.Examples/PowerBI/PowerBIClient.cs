using Newtonsoft.Json;
using RestLesser.Authentication;
using RestLesser.Examples.PowerBI.Models;
using System.Collections.Generic;
using System.Linq;

namespace RestLesser.Examples.PowerBI
{
    /// <remarks>
    /// PowerBI REST Client
    /// </remarks>
    /// <param name="authentication"></param>
    public class PowerBIClient(IAuthentication authentication) : RestClient("https://api.powerbi.com", authentication)
    {
        /// <summary>
        /// Get Report by guid
        /// </summary>
        /// <param name="report">Report</param>
        /// <param name="group">Workspace or null for own workspace</param>
        /// <returns></returns>
        public Report GetReport(Report report, Group group)
        {
            var url = group == null ? $"/v1.0/myorg/reports/{report.Id}" : $"/v1.0/myorg/groups/{group.Id}/reports/{report.Id}";
            return Get<Report>(url);
        }

        /// <summary>
        /// Get Reports
        /// </summary>
        /// <param name="group">Workspace or null for own workspace</param>
        /// <returns></returns>
        public Report[]? GetReports(Group group)
        {
            var url = group == null ? "/v1.0/myorg/reports" : $"/v1.0/myorg/groups/{group.Id}/reports";
            return Get<Reports>(url)?.Value;
        }

        /// <summary>
        /// Update Report content with existing Report
        /// </summary>
        /// <param name="report">Report</param>
        /// <param name="sourceReport">Source Report</param>
        /// <param name="sourceGroup">Source workspace</param>
        /// <param name="group">Workspace or null for onw workspace</param>
        /// <returns></returns>
        public Report UpdateReportContent(Report report, Report sourceReport, Group sourceGroup, Group group)
        {
            var url = group == null ? $"/v1.0/myorg/reports/{report.Id}/UpdateReportContent" : $"/v1.0/myorg/groups/{group.Id}/reports/{report.Id}/UpdateReportContent";
            var reportContent = new ReportContent
            {
                SourceReport = new SourceReport
                {
                    SourceReportId = sourceReport.Id,
                    SourceWorkspaceId = sourceGroup.Id
                },
                SourceType = "ExistingReport"
            };

            return Post<ReportContent, Report>(url, reportContent);
        }

        /// <summary>
        /// Get Groups (Workspaces)
        /// </summary>
        /// <returns></returns>
        public Group[]? GetGroups()
        {
            var url = "/v1.0/myorg/groups";
            return Get<Groups>(url)?.Value;
        }

        /// <summary>
        /// Refresh a dataset
        /// </summary>
        /// <param name="dataset">Dataset id</param>
        /// <param name="notifyOption">NotifyOption</param>
        /// <param name="group"></param>
        public void RefreshDataset(Dataset dataset, NotifyOption notifyOption, Group group)
        {
            var url = group == null ? $"/v1.0/myorg/datasets/{dataset.Id}/refreshes" :
                $"/v1.0/myorg/groups/{group.Id}/datasets/{dataset.Id}/refreshes";
            var body = new DatasetRefreshRequest
            {
                NotifyOption = notifyOption,
            };

            Post(url, body);
        }

        /// <summary>
        /// Clone a Report
        /// </summary>
        /// <param name="source">Source Report guid</param>
        /// <param name="destinationName">Destination report name</param>
        /// <param name="sourceGroup">Source workspace or null for own workspace</param>
        /// <param name="targetGroup">Destination workspace or null for own workspace</param>
        public Report CloneReport(Report source, string destinationName, Group sourceGroup, Group targetGroup)
        {
            var url = sourceGroup == null ? $"/v1.0/myorg/reports/{source.Id}/Clone" : $"/v1.0/myorg/groups/{sourceGroup.Id}/reports/{source.Id}/Clone";
            var body = new CloneReport
            {
                Name = destinationName,
                TargetWorkspaceId = targetGroup.Id
            };

            return Post<CloneReport, Report>(url, body);
        }

        /// <summary>
        /// Get Datasets
        /// </summary>
        /// <param name="group">Workspace or null for own workspace</param>
        /// <returns></returns>
        public Dataset[]? GetDataSets(Group group)
        {
            var url = group == null ? "/v1.0/myorg/datasets" : $"/v1.0/myorg/groups/{group.Id}/datasets";

            return Get<Datasets>(url)?.Value;
        }

        /// <summary>
        /// Get Dataset parameters 
        /// </summary>
        /// <param name="dataset">Dataset guid</param>
        /// <param name="group">Workspace or null for own workspace</param>
        /// <returns></returns>
        public MashupParameter[]? GetDataSetParameters(Dataset dataset, Group group)
        {
            var url = group == null ? $"/v1.0/myorg/datasets/{dataset.Id}/parameters" : $"/v1.0/myorg/groups/{group.Id}/datasets/{dataset.Id}/parameters";

            return Get<MashupParameters>(url)?.Value;
        }

        /// <summary>
        /// Update Dataset Parameters
        /// </summary>
        /// <param name="dataset">Dataset guid</param>
        /// <param name="parameters">Key/value parameters</param>
        /// <param name="group">Workspace or null for own workspace</param>
        public void UpdateDatasetParameters(Dataset dataset, IDictionary<string, string> parameters, Group group)
        {
            var url = group == null ? $"/v1.0/myorg/datasets/{dataset.Id}/Default.UpdateParameters" :
                $"/v1.0/myorg/groups/{group.Id}/datasets/{dataset.Id}/Default.UpdateParameters";

            var body = new UpdateMashupParameterDetails
            {
                UpdateDetails = parameters
                    .Select(p => new UpdateMashupParametersRequest
                    {
                        Name = p.Key,
                        NewValue = p.Value
                    })
                    .ToArray(),
            };

            Post(url, body);
        }

        /// <summary>
        /// Get EmbedToken
        /// </summary>
        /// <param name="report">Report guid</param>
        /// <param name="accesLevel">AccessLevel</param>
        /// <param name="allowSave">Allow report saving</param>
        /// <param name="group">Workspace of report</param>
        /// <returns></returns>
        public EmbedToken GetEmbedToken(Group group, Report report, bool allowSave, TokenAccessLevel accesLevel)
        {
            var url = $"/v1.0/myorg/groups/{group.Id}/reports/{report.Id}/GenerateToken";
            var body = new GenerateTokenRequest
            {
                AccessLevel = accesLevel,
                AllowSaveAs = allowSave,
            };

            return Post<GenerateTokenRequest, EmbedToken>(url, body);
        }

        /// <summary>
        /// Post a pbix file to a group
        /// </summary>
        /// <param name="group">Workspace or null for own workspace</param>
        /// <param name="conflictMode"></param>
        /// <param name="name">Name of dataset</param>
        /// <param name="path">Full path to the file</param>
        /// <returns></returns>
        public Import ImportPbix(string name, string path, Group group, ImportConflictHandlerMode conflictMode)
        {
            var url = group == null ? 
                $"/v1.0/myorg/imports?datasetDisplayName={name}&nameConflict={conflictMode}&overrideReportLabel=True&overrideModelLabel=True" :
                $"/v1.0/myorg/groups/{group.Id}/imports?datasetDisplayName={name}&nameConflict={conflictMode}&overrideReportLabel=True&overrideModelLabel=True";
            return PostFile<Import>(url, path);
        }

        /// <summary>
        /// Get an import
        /// </summary>
        /// <param name="import">Import guid</param>
        /// <param name="group">Workspace or null for onw workspace</param>
        /// <returns></returns>
        public Import GetImport(Import import, Group group)
        {
            var url = group == null ? $"/v1.0/myorg/imports/{import.Id}" : $"/v1.0/myorg/groups/{group.Id}/imports/{import.Id}";
            return Get<Import>(url);
        }

        /// <summary>
        /// Export a Report to a .pbix file
        /// </summary>
        /// <param name="report">Report guid</param>
        /// <param name="path">Full path to local file</param>
        /// <param name="group">Workspace or null for own workspace</param>
        public void ExportPbix(Report report, string path, Group group)
        {
            var url = group == null ? $"/v1.0/myorg/reports/{report.Id}/Export" : $"/v1.0/myorg/groups/{group.Id}/reports/{report.Id}/Export";
            GetFile(url, path, "application/zip");
        }

        /// <summary>
        /// Delete a report
        /// </summary>        
        /// <param name="report">Report guid</param>
        /// <param name="group">Workspace or null for own workspace</param>
        public void DeleteReport(Report report, Group group)
        {
            var url = group == null ? $"/v1.0/myorg/reports/{report.Id}" : $"/v1.0/myorg/groups/{group.Id}/reports/{report.Id}";
            Delete(url);
        }

        /// <summary>
        /// Delete a dataset
        /// </summary>
        /// <param name="dataset">Dataset guid</param>
        /// <param name="group">Workspace or null for own workspace</param>
        public void DeleteDataset(Dataset dataset, Group group)
        {
            var url = group == null ? $"/v1.0/myorg/datasets/{dataset.Id}" : $"/v1.0/myorg/groups/{group.Id}/datasets/{dataset.Id}";
            Delete(url);
        }

        /// <summary>
        /// Get datasource for given dataset
        /// </summary>
        /// <param name="dataset">Dataset</param>
        /// <param name="group">Workspace or null for own workspace</param>
        /// <returns>Workspace or null for own workspace</returns>
        public Datasource[]? GetDatasources(Dataset dataset, Group group)
        {
            var url = group == null ? $"/v1.0/myorg/datasets/{dataset.Id}/datasources" :
                $"/v1.0/myorg/groups/{group.Id}/datasets/{dataset.Id}/datasources";

            return Get<Datasources>(url)?.Value;
        }

        /// <summary>
        /// Update Datasource
        /// </summary>
        /// <param name="credentialDetails">Credentialdetails</param>
        /// <param name="datasource">Datasource</param>
        public void UpdateDatasource(Datasource datasource, CredentialDetails credentialDetails)
        {
            var url = $"/v1.0/myorg/gateways/{datasource.GatewayId}/datasources/{datasource.DatasourceId}";

            var updateSource = new UpdateDatasource
            {
                CredentialDetails = credentialDetails
            };

            Patch(url, updateSource);
        }

        /// <summary>
        /// Set basic auth on data source
        /// </summary>
        /// <param name="datasource"></param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        public void UpdateDatasourceBasicAuthentication(Datasource datasource, string username, string password)
        {
            var credentials = new Credentials
            {
                CredentialData =
                [
                    new NameValue("username", username),
                    new NameValue("password", password)
                ]
            };

            var credentialDetails = new CredentialDetails
            {
                CredentialType = CredentialType.Basic,
                PrivacyLevel = PrivacyLevel.Organizational,
                Credentials = JsonConvert.SerializeObject(credentials)
            };
           
            UpdateDatasource(datasource, credentialDetails);
        }

        /// <summary>
        /// Update dataset refresh schedule
        /// </summary>
        /// <param name="dataset">Datasource</param>
        /// <param name="schedule">Schedule</param>
        /// <param name="group">Workspace or null for onw workspace</param>
        public void UpdateRefreshSchedule(Dataset dataset, RefreshSchedule schedule, Group group)
        {
            var url = group == null ? $"/v1.0/myorg/datasets/{dataset.Id}/refreshSchedule" :
                $"/v1.0/myorg/groups/{group.Id}/datasets/{dataset.Id}/refreshSchedule";

            var request = new RefreshScheduleRequest
            {
                Value = schedule,
            };

            Patch(url, request);
        }

        /// <summary>
        /// Export a report to a file
        /// </summary>
        /// <param name="report">Report</param>
        /// <param name="format">File format</param>
        /// <param name="group">Workspace or null for own workspace</param>
        /// <returns>Export</returns>
        public Export ExportToFile(Report report, FileFormat format, Group group)
        {
            var url = group == null ? $"/v1.0/myorg/reports/{report.Id}/ExportTo" :
                $"/v1.0/myorg/groups/{group.Id}/reports/{report.Id}/ExportTo";

            var exportRequest = new ExportRequest
            {
                FileFormat = format
            };

            return Post<ExportRequest, Export>(url, exportRequest);
        }

        /// <summary>
        /// Get export
        /// </summary>
        /// <param name="report">Report</param>
        /// <param name="export">Export</param>
        /// <param name="group">Workspace or null for own workspace</param>
        /// <returns></returns>
        public Export GetExport(Report report, Export export, Group group)
        {
            var url = group == null ? $"/v1.0/myorg/reports/{report.Id}/exports/{export.Id}" :
                $"/v1.0/myorg/groups/{group.Id}/reports/{report.Id}/exports/{export.Id}";

            return Get<Export>(url);
        }

        /// <summary>
        /// Download export file
        /// </summary>
        /// <param name="report">Report</param>
        /// <param name="export">Export</param>
        /// <param name="path">Full path of local file</param>
        /// <param name="mediatype">Media type</param>
        /// <param name="group">Workspace or null for onw workspace</param>
        public void GetExportFile(Report report, Export export, string path, string mediatype, Group group)
        {
            var url = group == null ? $"/v1.0/myorg/reports/{report.Id}/exports/{export.Id}/file" : 
                $"/v1.0/myorg/groups/{group.Id}/reports/{report.Id}/exports/{export.Id}/file";

            GetFile(url, path, mediatype);
        }
    }
}
