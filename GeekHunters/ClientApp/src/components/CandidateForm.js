import React from 'react';
import { Form, FormGroup, Label, Input, Container, Button } from 'reactstrap';
import { fetchSkills, submitCandidate } from '../api';
import { Link } from 'react-router-dom';
import './CandidateForm.css';

export default class CandidateForm extends React.PureComponent {
    constructor(props) {
        super(props);
        this.state = { allSkills: [], firstName: '', lastName: '', skills: [] };
        
        this.onChange = this.onChange.bind(this);
        this.onSkillChange = this.onSkillChange.bind(this);
        this.onSubmit = this.onSubmit.bind(this);
    }

    async componentDidMount() {
        this.setState({
            allSkills: await fetchSkills(),
        });
    }

    render() {
        const { firstName, lastName, skills, allSkills } = this.state;
        return <Container className='CandidateForm'>
            <Form onSubmit={this.onSubmit}>
                <FormGroup>
                    <Label for="firstName">First Name</Label>
                    <Input name="firstName" id="firstName" value={firstName} onChange={this.onChange} />
                </FormGroup>
                <FormGroup>
                    <Label for="lastName">Last Name</Label>
                    <Input name="lastName" id="lastName" value={lastName} onChange={this.onChange} />
                </FormGroup>
                <FormGroup>
                    <Label for="skills">Skills
                        <span className='hint'>(hold CTRL to select multiple)</span>
                    </Label>
                    <Input type="select" name="skills" id="skills" multiple value={skills} className='skills' onChange={this.onSkillChange}>
                        {allSkills.map(s => <option key={s.id} value={s.id}>{s.name}</option>)}
                    </Input>
                </FormGroup>
                <FormGroup>
                    <Button color='primary' type='submit'>Save</Button>
                    <Button tag={Link} to='/' color='danger'>Back</Button>
                </FormGroup>
            </Form>
        </Container>;
    }

    onChange(e) {
        this.setState({ [e.currentTarget.name]: e.currentTarget.value })
    }

    onSkillChange(e) {
        this.setState({
            skills: [ ...e.currentTarget.options ].filter(o => o.selected).map(o => parseInt(o.value, 10))
        })        
    }

    onSubmit(e) {
        e.preventDefault();

        const { firstName, lastName, skills } = this.state;
        submitCandidate(firstName, lastName, skills);
        this.props.history.goBack();
        // setTimeout(() => window.location.reload(), 1000);
    }
}