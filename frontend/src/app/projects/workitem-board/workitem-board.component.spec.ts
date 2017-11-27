import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { WorkitemBoardComponent } from './workitem-board.component';

describe('WorkitemBoardComponent', () => {
  let component: WorkitemBoardComponent;
  let fixture: ComponentFixture<WorkitemBoardComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ WorkitemBoardComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(WorkitemBoardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
