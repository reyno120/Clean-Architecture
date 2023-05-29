import React, { useState } from 'react'
import { Form, FormGroup, Label, Input } from 'reactstrap'
import { Col, Row } from 'reactstrap'
import { Navbar } from 'reactstrap';
import { Button } from 'reactstrap'
import { PlusCircleFill, DashCircleFill, CheckSquareFill } from 'react-bootstrap-icons'
import { useMutation } from 'react-query'
import axios from 'axios'

export function Create() {
    const [directions, setDirections] = useState([]);
    const [name, setName] = useState('');
    const [description, setDescription] = useState('');
    const [image, setImage] = useState(null);

    const mutation = useMutation({
        mutationFn: (newRecipe) => {
            return axios.post('/create', newRecipe, {
                headers: {
                    'Content-Type': 'multipart/form-data'
                }
            });
        }
    })

    function onSubmit(e) {
        e.preventDefault();

        var newRecipe = {
            name: name,
            description: description,
            image: image,
            directions: directions.map((direction, i) => {
                return { stepNumber: i + 1, direction: direction.direction };
            })
        }

        mutation.mutate(newRecipe);
    }

    function addDirection() {
        const newId = crypto.randomUUID();
        setDirections(current => [...current, {id: newId, direction: ''}]);
    }

    function removeDirection(id) {
        setDirections(directions.filter((value, i) => value.id !== id));
    }

    function handleDirectionChange(value, id) {
        const nextDirections = directions.map((direction, i) => {
            if (direction.id === id) return {id: id, direction: value};
            return direction;
        });
        setDirections(nextDirections);
    }

    function addImage(e) {
        setImage(e.target.files[0]);
    }

    const addDirectionComponent = () => {
        return (
            <Row className="align-items-center">
                <Col xs={'auto'}>
                    <PlusCircleFill
                        size={'1.5rem'}
                        style={{ cursor: 'pointer', color: 'gray' }}
                        onMouseOver={(e) => e.target.style.color = "green"}
                        onMouseOut={(e) => e.target.style.color = "gray"}
                        onClick={() => addDirection()}
                    />
                </Col>
                <Col >
                    <Input
                        name="Description"
                        type="text"
                        disabled
                        placeholder="Add a step"
                    />
                </Col>
            </Row>);
    }

    function listOfDirections() {
        return (
            directions.map((direction) =>
                <Row
                    className="align-items-center"
                    style={{paddingBottom: '15px'}}
                    key={direction.id}
                >
                    <Col xs={'auto'}>
                        <DashCircleFill
                            size={'1.5rem'}
                            style={{ cursor: 'pointer', color: 'gray' }}
                            onMouseOver={(e) => e.target.style.color = "red"}
                            onMouseOut={(e) => e.target.style.color = "gray"}
                            onClick={() => removeDirection(direction.id)}
                        />
                    </Col>
                    <Col>
                        <Input
                            name="Description"
                            type="text"
                            defaultValue={direction.direction}
                            onChange={(e) => handleDirectionChange(e.target.value, direction.id)}
                        />
                    </Col>
                </Row>)
        );
    }

    return (
        <div>

                        {mutation.isLoading ? ('Creating Recipe') : null}
                        {mutation.isError ? ('Error') : null }
                        {mutation.isSuccess ? ('Success') : null }

            <Form style={{overflowY: 'auto', overflowX: 'hidden'}}>
                <FormGroup>
                    <Label
                        for="Name"
                        sm={2}
                    >
                        Recipe Name
                    </Label>
                    <Col sm={10}>
                        <Input
                            id="Name"
                            name="Name"
                            placeholder='Grilled Portobella "Steaks"'
                            type="text"
                            onChange={(e) => {setName(e.target.value)}}
                        />
                    </Col>
                </FormGroup>
                <FormGroup>
                    <Label
                        for="Description"
                        sm={2}
                    >
                        Description
                    </Label>
                    <Col sm={10}>
                        <Input
                            id="Description"
                            name="Description"
                            placeholder='Portobella mushrooms grilled to perfection'
                            type="text"
                            onChange={(e) => {setDescription(e.target.value)}}
                        />
                    </Col>
                </FormGroup>
                <FormGroup>
                    <Label
                        for="Image"
                        sm={2}
                    >
                        Upload Image
                    </Label>
                    <Col sm={6}>
                        <Input
                            id="Image"
                            name="Image"
                            type="file"
                            onChange={(e) => addImage(e)}
                        />
                    </Col>
                </FormGroup>

                <FormGroup>
                    {image != null ?
                        <img
                            src={URL.createObjectURL(image)}
                            style={{ width: '300px', height: '200px' }} />
                        : ''}
                </FormGroup>

                
                <Label
                    sm={2}
                >
                    Directions
                </Label>
                <FormGroup style={{paddingBottom: '100px'}}>

                    {listOfDirections()}
                    {directions.length < 15 ? addDirectionComponent() : ''}

                </FormGroup>
            </Form>

            <Navbar fixed='bottom' color='light' expand='md' container>
                <CheckSquareFill
                    size="30px"
                    color="green"
                    cursor="pointer"
                    style={{ marginLeft: 'auto' }}
                    onClick={(e) => onSubmit(e)}
                />
            </Navbar>
        </div>
    );
}