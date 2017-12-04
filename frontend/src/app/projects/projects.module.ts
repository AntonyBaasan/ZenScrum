import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { ProjectsRoutingModule } from './projects-routing.module';
import { ProjectHeaderComponent } from './project-header/project-header.component';
import { WorkitemListComponent } from './workitem-list/workitem-list.component';
import { WorkitemComponent } from './workitem/workitem.component';
import { IterationListComponent } from './iteration-list/iteration-list.component';
import { ProjectBodyComponent } from './project-body/project-body.component';
import { WorkitemBoardComponent } from './workitem-board/workitem-board.component';
import { ProjectsComponent } from './projects/projects.component';
import { ProjectListComponent } from './project-list/project-list.component';

// material component
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatListModule } from '@angular/material/list';
import { MatIconModule } from '@angular/material/icon';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    ProjectsRoutingModule,
    MatSidenavModule,
    MatCheckboxModule,
    MatListModule,
    MatIconModule
  ],
  declarations: [ProjectHeaderComponent,
    WorkitemListComponent,
    WorkitemComponent,
    IterationListComponent,
    ProjectBodyComponent,
    WorkitemBoardComponent,
    ProjectsComponent,
    ProjectListComponent]
})
export class ProjectsModule { }
