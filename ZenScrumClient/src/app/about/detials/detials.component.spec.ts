/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { DetialsComponent } from './detials.component';

describe('DetialsComponent', () => {
  let component: DetialsComponent;
  let fixture: ComponentFixture<DetialsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DetialsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DetialsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
