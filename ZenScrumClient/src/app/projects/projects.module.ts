import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ProjectsRoutingModule } from './projects-routing.module';
import { ProjectHeaderComponent } from './project-header/project-header.component';
import { WorkitemListComponent } from './workitem-list/workitem-list.component';
import { WorkitemComponent } from './workitem/workitem.component';
import { IterationListComponent } from './iteration-list/iteration-list.component';
import { ProjectBodyComponent } from './project-body/project-body.component';
import { WorkitemBoardComponent } from './workitem-board/workitem-board.component';
import { ProjectsComponent } from './projects/projects.component';

@NgModule({
  imports: [
    CommonModule,
    ProjectsRoutingModule
  ],
  declarations: [ProjectHeaderComponent,
    WorkitemListComponent,
    WorkitemComponent,
    IterationListComponent,
    ProjectBodyComponent,
    WorkitemBoardComponent,
    ProjectsComponent]
})
export class ProjectsModule { }
