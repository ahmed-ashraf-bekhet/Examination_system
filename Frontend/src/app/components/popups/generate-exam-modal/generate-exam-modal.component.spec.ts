import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { GenerateExamModalComponent } from './generate-exam-modal.component';

describe('GenerateExamModalComponent', () => {
  let component: GenerateExamModalComponent;
  let fixture: ComponentFixture<GenerateExamModalComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ GenerateExamModalComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(GenerateExamModalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
