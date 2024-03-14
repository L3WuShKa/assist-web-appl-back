using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace ProjectManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeRepository _repository;

        public EmployeeController(EmployeeRepository repository)
        {
            _repository = repository;
        }

        [HttpPost("signup/organization-admin")]
        public IActionResult SignUpAsOrganizationAdmin(OrganizationAdminSignupRequest request)
        {
            _repository.SignUpAsOrganizationAdmin(request);
            return Ok();
        }

        [HttpGet("signup/employee")]
        public IActionResult GetEmployeeSignUpUrl()
        {
            var signupUrl = _repository.GetEmployeeSignUpUrl();
            return Ok(signupUrl);
        }

        [HttpPost("signup/employee")]
        public IActionResult SignUpAsEmployee(EmployeeSignupRequest request)
        {
            _repository.SignUpAsEmployee(request);
            return Ok();
        }

        [HttpGet("roles")]
        public IActionResult GetAccessRoles()
        {
            var roles = _repository.GetAccessRoles();
            return Ok(roles);
        }

        [HttpPost("roles/assign")]
        public IActionResult AssignAccessRoles(AccessRoleAssignmentRequest request)
        {
            _repository.AssignAccessRoles(request);
            return Ok();
        }

        [HttpGet("custom-team-roles")]
        public IActionResult GetCustomTeamRoles()
        {
            var customRoles = _repository.GetCustomTeamRoles();
            return Ok(customRoles);
        }

        [HttpPost("custom-team-roles")]
        public IActionResult CreateOrUpdateCustomTeamRoles(List<CustomTeamRole> roles)
        {
            _repository.CreateOrUpdateCustomTeamRoles(roles);
            return Ok();
        }

        [HttpPost("department")]
        public IActionResult CreateDepartment(DepartmentCreationRequest request)
        {
            _repository.CreateDepartment(request);
            return Ok();
        }

        [HttpPut("department/{departmentId}")]
        public IActionResult UpdateDepartment(int departmentId, DepartmentUpdateRequest request)
        {
            _repository.UpdateDepartment(departmentId, request);
            return Ok();
        }

        [HttpDelete("department/{departmentId}")]
        public IActionResult DeleteDepartment(int departmentId)
        {
            _repository.DeleteDepartment(departmentId);
            return Ok();
        }

        [HttpPost("department/{departmentId}/manager")]
        public IActionResult AssignDepartmentManager(int departmentId, DepartmentManagerAssignmentRequest request)
        {
            _repository.AssignDepartmentManager(departmentId, request);
            return Ok();
        }

        [HttpGet("department/{departmentId}/unassigned-employees")]
        public IActionResult GetUnassignedEmployees(int departmentId)
        {
            var unassignedEmployees = _repository.GetUnassignedEmployees(departmentId);
            return Ok(unassignedEmployees);
        }

        [HttpPost("department/{departmentId}/assign-employee")]
        public IActionResult AssignEmployeeToDepartment(int departmentId, EmployeeAssignmentRequest request)
        {
            _repository.AssignEmployeeToDepartment(departmentId, request);
            return Ok();
        }

        [HttpDelete("department/{departmentId}/unassign-employee/{employeeId}")]
        public IActionResult UnassignEmployeeFromDepartment(int departmentId, int employeeId)
        {
            _repository.UnassignEmployeeFromDepartment(departmentId, employeeId);
            return Ok();
        }

        [HttpPost("department/{departmentId}/skills")]
        public IActionResult CreateSkill(int departmentId, SkillCreationRequest request)
        {
            _repository.CreateSkill(departmentId, request);
            return Ok();
        }

        [HttpPut("department/{departmentId}/skills/{skillId}")]
        public IActionResult UpdateSkill(int departmentId, int skillId, SkillUpdateRequest request)
        {
            _repository.UpdateSkill(departmentId, skillId, request);
            return Ok();
        }

        [HttpDelete("department/{departmentId}/skills/{skillId}")]
        public IActionResult DeleteSkill(int departmentId, int skillId)
        {
            _repository.DeleteSkill(departmentId, skillId);
            return Ok();
        }

        [HttpPost("skills/assign")]
        public IActionResult AssignSkill(SkillAssignmentRequest request)
        {
            _repository.AssignSkill(request);
            return Ok();
        }

        [HttpGet("skills")]
        public IActionResult GetEmployeeSkills()
        {
            var skills = _repository.GetEmployeeSkills();
            return Ok(skills);
        }

        [HttpPost("projects")]
        public IActionResult CreateProject(ProjectCreationRequest request)
        {
            _repository.CreateProject(request);
            return Ok();
        }

        [HttpPut("projects/{projectId}")]
        public IActionResult UpdateProject(int projectId, ProjectUpdateRequest request)
        {
            _repository.UpdateProject(projectId, request);
            return Ok();
        }

        [HttpDelete("projects/{projectId}")]
        public IActionResult DeleteProject(int projectId)
        {
            _repository.DeleteProject(projectId);
            return Ok();
        }

        [HttpPost("projects/{projectId}/team-roles")]
        public IActionResult SetProjectTeamRoles(int projectId, List<ProjectTeamRole> roles)
        {
            _repository.SetProjectTeamRoles(projectId, roles);
            return Ok();
        }

        [HttpGet("projects/{projectId}/team-members")]
        public IActionResult GetProjectTeamMembers(int projectId)
        {
            var teamMembers = _repository.GetProjectTeamMembers(projectId);
            return Ok(teamMembers);
        }

        [HttpPost("projects/{projectId}/team-members")]
        public IActionResult AssignTeamMemberToProject(int projectId, TeamMemberAssignmentRequest request)
        {
            _repository.AssignTeamMemberToProject(projectId, request);
            return Ok();
        }

        [HttpPost("projects/{projectId}/team-members/deallocation")]
        public IActionResult ProposeTeamMemberDeallocation(int projectId, TeamMemberDeallocationProposal proposal)
        {
            _repository.ProposeTeamMemberDeallocation(projectId, proposal);
            return Ok();
        }

        [HttpGet("projects/{projectId}/assignments")]
        public IActionResult GetAssignmentProposals(int projectId)
        {
            var proposals = _repository.GetAssignmentProposals(projectId);
            return Ok(proposals);
        }

        [HttpPost("projects/{projectId}/assignments/{assignmentId}/confirmation")]
        public IActionResult ConfirmAssignmentProposal(int projectId, int assignmentId, AssignmentConfirmation confirmation)
        {
            _repository.ConfirmAssignmentProposal(projectId, assignmentId, confirmation);
            return Ok();
        }

        [HttpGet("projects/{projectId}/team-view")]
        public IActionResult GetProjectTeamView(int projectId)
        {
            var teamView = _repository.GetProjectTeamView(projectId);
            return Ok(teamView);
        }

        [HttpGet("my-projects")]
        public IActionResult GetEmployeeProjects()
        {
            var projects = _repository.GetEmployeeProjects();
            return Ok(projects);
        }

        [HttpGet("department-projects")]
        public IActionResult GetDepartmentProjects()
        {
            var projects = _repository.GetDepartmentProjects();
            return Ok(projects);
        }

        [HttpGet("projects/{projectId}")]
        public IActionResult GetProjectDetails(int projectId)
        {
            var projectDetails = _repository.GetProjectDetails(projectId);
            return Ok(projectDetails);
        }

        [HttpPost("skill-endorsements")]
        public IActionResult AddSkillEndorsement(SkillEndorsementRequest request)
        {
            _repository.AddSkillEndorsement(request);
            return Ok();
        }

        [HttpGet("skill-validation")]
        public IActionResult GetSkillValidationRequests()
        {
            var validationRequests = _repository.GetSkillValidationRequests();
            return Ok(validationRequests);
        }

        [HttpPost("skill-validation/{requestId}/confirmation")]
        public IActionResult ConfirmSkillValidation(int requestId, SkillValidationConfirmation confirmation)
        {
            _repository.ConfirmSkillValidation(requestId, confirmation);
            return Ok();
        }

        [HttpPost("projects/{projectId}/skill-requirements")]
        public IActionResult AddSkillRequirementsToProject(int projectId, List<SkillRequirement> requirements)
        {
            _repository.AddSkillRequirementsToProject(projectId, requirements);
            return Ok();
        }

        [HttpGet("skill-upgrade-proposals")]
        public IActionResult GetSkillUpgradeProposals()
        {
            var proposals = _repository.GetSkillUpgradeProposals();
            return Ok(proposals);
        }

        [HttpPost("skill-upgrade-proposals/{proposalId}/confirmation")]
        public IActionResult ConfirmSkillUpgradeProposal(int proposalId, SkillUpgradeConfirmation confirmation)
        {
            _repository.ConfirmSkillUpgradeProposal(proposalId, confirmation);
            return Ok();
        }

        [HttpPost("find-experts")]
        public IActionResult FindExperts(ExpertSearchRequest request)
        {
            var experts = _repository.FindExperts(request);
            return Ok(experts);
        }

        [HttpGet("notifications")]
        public IActionResult GetNotifications()
        {
            var notifications = _repository.GetNotifications();
            return Ok(notifications);
        }

        [HttpGet("skill-statistics")]
        public IActionResult GetSkillStatistics()
        {
            var statistics = _repository.GetSkillStatistics();
            return Ok(statistics);
        }
    }
}
