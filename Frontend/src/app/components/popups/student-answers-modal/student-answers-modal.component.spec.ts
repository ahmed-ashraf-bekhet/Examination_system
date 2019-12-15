import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { StudentAnswersModalComponent } from './student-answers-modal.component';

describe('StudentAnswersModalComponent', () => {
  let component: StudentAnswersModalComponent;
  let fixture: ComponentFixture<StudentAnswersModalComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ StudentAnswersModalComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(StudentAnswersModalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
