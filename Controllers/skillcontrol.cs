using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TeamFinder.Models;
using TeamFinder.Services;

namespace TeamFinder.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillController : ControllerBase
    {
        private readonly ISkillService _skillService;

        public SkillController(ISkillService skillService)
        {
            _skillService = skillService;
        }

        // Endpoint pentru obținerea tuturor abilităților
        [HttpGet]
        public async Task<IActionResult> GetSkills()
        {
            var skills = await _skillService.GetSkillsAsync();
            return Ok(skills);
        }

        // Endpoint pentru obținerea unei abilități după ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSkillById(int id)
        {
            var skill = await _skillService.GetSkillByIdAsync(id);
            if (skill == null)
            {
                return NotFound();
            }
            return Ok(skill);
        }

        // Endpoint pentru crearea unei noi abilități
        [HttpPost]
        public async Task<IActionResult> CreateSkill([FromBody] Skill skill)
        {
            var createdSkill = await _skillService.CreateSkillAsync(skill);
            return CreatedAtAction(nameof(GetSkillById), new { id = createdSkill.Id }, createdSkill);
        }

        // Endpoint pentru actualizarea unei abilități existente
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSkill(int id, [FromBody] Skill skill)
        {
            if (id != skill.Id)
            {
                return BadRequest("ID-ul abilității nu corespunde.");
            }

            var updatedSkill = await _skillService.UpdateSkillAsync(skill);
            if (updatedSkill == null)
            {
                return NotFound("Abilitatea nu a fost găsită.");
            }

            return Ok(updatedSkill);
        }

        // Endpoint pentru ștergerea unei abilități existente
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSkill(int id)
        {
            var deletedSkill = await _skillService.DeleteSkillAsync(id);
            if (deletedSkill == null)
            {
                return NotFound("Abilitatea nu a fost găsită.");
            }

            return Ok(deletedSkill);
        }
    }
}
