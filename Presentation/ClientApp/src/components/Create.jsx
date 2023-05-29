import React, { useState } from 'react'
import { Form, FormGroup, Label, Input, FormFeedback, Alert } from 'reactstrap'
import { Col, Row } from 'reactstrap'
import { Navbar } from 'reactstrap';
import { Spinner } from 'reactstrap'
import { PlusCircleFill, DashCircleFill, CheckSquareFill } from 'react-bootstrap-icons'
import { useMutation } from 'react-query'
import axios from 'axios'
import Swal from 'sweetalert2'
import withReactContent from 'sweetalert2-react-content'

export function Create() {
    const [directions, setDirections] = useState([]);
    const [name, setName] = useState('');
    const [description, setDescription] = useState('');
    const [image, setImage] = useState(null);
    const [showAlert, setShowAlert] = useState(false);
    const [valid, setValid] = useState({
        name: true,
        description: true
    })
    const MySwal = withReactContent(Swal)

    const mutation = useMutation({
        mutationFn: (newRecipe) => {
            return axios.post('/create', newRecipe, {
                headers: {
                    'Content-Type': 'multipart/form-data'
                }
            }).then(function () {
                MySwal.fire({
                    title: <strong>Success!</strong>,
                    confirmButtonColor: '#3B71CA',
                    icon: 'success'
                }).then(function () {
                    window.location.replace('/');
                })
            }).catch(function (error) {
                MySwal.fire({
                    title: <strong>{error}</strong>,
                    confirmButtonColor: '#3B71CA',
                    icon: 'error'
                })
            });
        }
    })

    const spinnerClass = {
        position: 'fixed',
        top: '0',
        left: '0',
        width: '100%',
        height: '100vh',
        zIndex: '2000',
        backgroundColor: 'rgb(0, 0, 0, 0.5)',
        display: 'flex',
        alignItems: 'center',
        justifyContent: 'center'
    }

    function onSubmit(e) {
        e.preventDefault();
        if (!validateForm()) {
            return;
        }

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

    function validateForm() {
        if (name == '') {
            setValid({ name: false, description: true });
            return false;
        }

        if (description == '') {
            setValid({ name: true, description: false })
            return false;
        }

        if (directions.length == 0) {
            setShowAlert(true);
            return false;
        }

        for (var i = 0; i < directions.length; i++) {
            if (directions[i].direction == '') {
                setShowAlert(true);
                return false;
            } 
        }

        setValid({ name: true, description: true });
        setShowAlert(false);

        return true;
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

            {/*{mutation.isLoading ? <Spinner /> : null}*/}

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
                            onChange={(e) => { setName(e.target.value) }}
                            invalid={!valid.name}
                        />
                        <FormFeedback>Recipe name is required</FormFeedback>
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
                            onChange={(e) => { setDescription(e.target.value) }}
                            invalid={!valid.description}
                        />
                        <FormFeedback>Recipe description is required</FormFeedback>
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
                <Alert isOpen={showAlert} color="danger">Must have at least one direction and directions cannot be blank!</Alert>
                <FormGroup style={{paddingBottom: '100px'}}>

                    {listOfDirections()}
                    {directions.length < 15 ? addDirectionComponent() : ''}

                </FormGroup>

                <div style={mutation.isLoading ? spinnerClass : { display: 'none' }}>
                    <Spinner
                        style={{ position: 'relative', top: '-30%' }} />
                </div>
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