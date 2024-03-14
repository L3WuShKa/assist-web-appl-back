using System;
using System.Collections.Generic;

// Definim clasa Skill
public class Skill
{
    // Proprietăți pentru informațiile despre abilitate
    public string SkillCategory { get; set; }
    public string SkillName { get; set; }
    public string Description { get; set; }
    public string Author { get; set; }
    public List<string> Departments { get; set; }

    // Constructorul clasei Skill
    public Skill(string skillCategory, string skillName, string description, string author)
    {
        SkillCategory = skillCategory;
        SkillName = skillName;
        Description = description;
        Author = author;
        Departments = new List<string>();
    }

    // Metoda pentru adăugarea unui departament în care se folosește abilitatea
    public void AddDepartment(string department)
    {
        Departments.Add(department);
    }

    // Metoda pentru actualizarea informațiilor despre abilitate
    public void UpdateSkill(string skillCategory, string skillName, string description)
    {
        SkillCategory = skillCategory;
        SkillName = skillName;
        Description = description;
    }
}

// Clasa pentru gestionarea abilităților
public class SkillManager
{
    private List<Skill> skills; // Listă pentru stocarea abilităților

    // Constructorul clasei SkillManager
    public SkillManager()
    {
        skills = new List<Skill>();
    }

    // Metoda pentru adăugarea unei abilități
    public void AddSkill(string skillCategory, string skillName, string description, string author)
    {
        Skill newSkill = new Skill(skillCategory, skillName, description, author);
        skills.Add(newSkill);
    }

    // Metoda pentru actualizarea unei abilități existente
    public void UpdateSkill(string skillName, string skillCategory, string newSkillName, string description)
    {
        Skill skillToUpdate = skills.Find(skill => skill.SkillName == skillName);
        if (skillToUpdate != null)
        {
            skillToUpdate.UpdateSkill(skillCategory, newSkillName, description);
        }
    }

    // Metoda pentru adăugarea unui departament la o abilitate existentă
    public void AddDepartmentToSkill(string skillName, string department)
    {
        Skill skillToUpdate = skills.Find(skill => skill.SkillName == skillName);
        if (skillToUpdate != null)
        {
            skillToUpdate.AddDepartment(department);
        }
    }
}
