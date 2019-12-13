import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AssignStudentModalComponent } from './assign-student-modal.component';

describe('AssignStudentModalComponent', () => {
  let component: AssignStudentModalComponent;
  let fixture: ComponentFixture<AssignStudentModalComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AssignStudentModalComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AssignStudentModalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
