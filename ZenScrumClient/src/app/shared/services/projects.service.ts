import { Injectable } from '@angular/core';
import { Project } from '../models/project';

@Injectable()
export class ProjectsService {

  constructor() { }

  public GetProjects(): Project[] {
    return [
      { Id: 1, Name: 'Pro1', Details: 'Detals1', Moniker: 'Moniker1' },
      { Id: 2, Name: 'Pro2', Details: 'Detals2', Moniker: 'Moniker2' }
    ];
  }

}
