import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ProjectsService } from './services/projects.service';

@NgModule({
  imports: [
    CommonModule
  ],
  declarations: [],
  providers: [ProjectsService]
})
export class SharedModule { }
