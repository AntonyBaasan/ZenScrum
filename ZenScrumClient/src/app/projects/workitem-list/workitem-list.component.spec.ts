import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { WorkitemListComponent } from './workitem-list.component';

describe('WorkitemListComponent', () => {
  let component: WorkitemListComponent;
  let fixture: ComponentFixture<WorkitemListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ WorkitemListComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(WorkitemListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
