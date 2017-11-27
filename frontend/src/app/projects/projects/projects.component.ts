import { Component, OnInit } from '@angular/core';

import { ProjectsService } from '../../shared/services/projects.service';
import { Project } from '../../shared/models/project';

@Component({
  selector: 'app-projects',
  templateUrl: './projects.component.html',
  styleUrls: ['./projects.component.css']

})
export class ProjectsComponent implements OnInit {

  public projects: Project[];

  constructor(public projectsService: ProjectsService) { }

  ngOnInit() {
    this.projects = this.projectsService.GetProjects();
  }

}
