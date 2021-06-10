import { PacientBasicInfo } from '../pacient/pacient-basic-info';
import { PsychologistBasicInfo } from '../psychologist/psychologist-basic-info';

export interface ConsultationBasicInfo {
    cost: number;
    psychologist: PsychologistBasicInfo;
}