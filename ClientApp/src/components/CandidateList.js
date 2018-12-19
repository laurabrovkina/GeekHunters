import React from 'react';
import { Link } from 'react-router-dom';
import { Button, Form, FormGroup, Input, Label, Table } from 'reactstrap';
import { fetchCandidates, fetchSkills } from '../api';

export default class CandidateList extends React.PureComponent {
    constructor(props) {
        super(props);
        this.state = { list: [], allSkills: [] };
        this.onSkillChange = this.onSkillChange.bind(this);
    }

    async componentDidMount() {
        this.setState({
            list: await fetchCandidates(),
            allSkills: await fetchSkills(),
        })
    }

    render() {
        const { skill, allSkills } = this.state;
        return <div>
            <h1>List of Candidates</h1>
            <Form inline className="flex-row-reverse">
                <FormGroup className="mb-2">
                    <Label for="skill" className="mr-sm-2">Filter by skill:</Label>
                    <Input id="skill" type="select" onChange={this.onSkillChange} value={skill}>
                        <option value=''>(All)</option>
                        {allSkills.map(s => <option key={s.id} value={s.name}>{s.name}</option>)}
                    </Input>
                </FormGroup>
            </Form>
            <Table>
                <thead>
                    <tr>
                        <th>First Name</th>
                        <th>Last Name</th>
                        <th>Skills</th>
                    </tr>
                </thead>
                <tbody>
                    {this.state.list.filter(c => skill === undefined || c.skills.includes(skill)).map(c => <tr key={c.id}>
                        <td>{c.firstName}</td>
                        <td>{c.lastName}</td>
                        <td>{c.skills.join(', ')}</td>
                    </tr>)}
                </tbody>
            </Table>
            <Button color='primary' tag={Link} to='/add'>Add Candidate</Button>
        </div>
    }

    onSkillChange(e) {
        const skill = e.currentTarget.value;
        this.setState({
            skill: skill || undefined
        })
    }
}